using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Application.Models;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Application.Features.Queries.Chats.SendMessage;

/// <summary>
/// Обработчик для <see cref="SendMessageCommand"/>
/// </summary>
public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
{
    private readonly IHubService _hubService;
    private readonly IDbContext _dbContext;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IUserContext _userContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dateTimeProvider">Провайдер дат</param>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="hubService">Сервис для работы с хабом</param>
    /// <param name="userContext">Контекст текущего пользователя</param>
    public SendMessageCommandHandler(
        IDateTimeProvider dateTimeProvider,
        IDbContext dbContext,
        IHubService hubService,
        IUserContext userContext)
    {
        _dateTimeProvider = dateTimeProvider;
        _dbContext = dbContext;
        _hubService = hubService;
        _userContext = userContext;
    }

    /// <inheritdoc />
    public async Task Handle(SendMessageCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var currentUser = await _dbContext.UserInfos
            .FirstOrDefaultAsync(x => x.UserId == _userContext.CurrentUserId, cancellationToken)
            ?? throw new ApplicationException("Не найдена информация о текущем пользователе");
        
        var chatFromDb = await _dbContext.Chats
            .Include(x => x.UserInfos)
                .ThenInclude(y => y.Image)
            .Include(x => x.UserInfos)
                .ThenInclude(y => y.User)
            .Include(x => x.Messages)
            .Where(x => x.Id == request.ChatId && x.UserInfos.Any(y => y.UserId == _userContext.CurrentUserId))
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new ApplicationException("Не найден чат у текущего пользователя");
        
        
        chatFromDb.Messages.Add(new Messages
        {
            CreatedBy = _userContext.CurrentUserId,
            CreatedDate = _dateTimeProvider.CurrentDate,
            Message = request.Message,
            UserInfoId = currentUser.Id,
            UserInfo = currentUser,
        });
        
        await _hubService.SendNewMessageAsync(new SendMessageModel
        {
            Text = request.Message,
            IsYourMessage = _userContext.CurrentUserId == currentUser.UserId,
            SentTo = chatFromDb.UserInfos
                .Select(x => x.UserId)
                .ToList(),
            WhoSentId = _userContext.CurrentUserId,
            Images = chatFromDb.UserInfos
                .Where(x => x.UserId != _userContext.CurrentUserId)
                .ToDictionary(x => x.UserId,
                    x => x.Image?.Path),
            SenderName = chatFromDb.UserInfos
                .FirstOrDefault(x => x.UserId == _userContext.CurrentUserId)?.User?.UserName
        });
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}