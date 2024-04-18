using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Chats.GetMessagesChats;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Chats.GetMessagesChats;

/// <summary>
/// Обработчик для <see cref="GetMessagesChatsQuery"/>
/// </summary>
public class GetMessagesChatsQueryHandler
    : IRequestHandler<GetMessagesChatsQuery, GetMessagesChatsResponse>
{
    private const int TakeCountMessages = 50;
    
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="userContext">Контекст БД</param>
    public GetMessagesChatsQueryHandler(IDbContext dbContext, IUserContext userContext)
    {
        _dbContext = dbContext;
        _userContext = userContext;
    }

    /// <inheritdoc />
    public async Task<GetMessagesChatsResponse> Handle(
        GetMessagesChatsQuery request,
        CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return await _dbContext.Chats
            .Where(x => x.UserInfos.Any(y => y.UserId == _userContext.CurrentUserId))
            .Where(x => x.Id == request.ChatId)
            .GroupJoin(
                _dbContext.Messages,
                chat => chat.Id,
                message => message.ChatId,
                (chat, message) => new
                {
                    Chat = chat,
                    Message = message,
                })
            .Select(x => new GetMessagesChatsResponse
            {
                ChatImage = x.Chat.UserInfos.Count() > 2
                    ? x.Chat.MediaFile!.Path
                    : x.Chat.UserInfos!
                        .FirstOrDefault(y => y.UserId != _userContext.CurrentUserId)!.Image!.Path,
                ChatId = x.Chat.Id,
                ChatTitle = x.Chat.UserInfos.Count() > 2
                    ? x.Chat.TitleChat
                    : x.Chat.UserInfos
                        .FirstOrDefault(y => y.UserId != _userContext.CurrentUserId)!.User!.UserName,
               IsGroup = x.Chat.UserInfos.Count() > 2,
                Messages = x.Message
                    .OrderBy(y => y.CreatedDate)
                    .Take(TakeCountMessages)
                    .Select(y => new GetMessagesChatsResponseItem
                    {
                        Message = y.Message,
                        ReceiveMessageName = y.UserInfo!.User!.UserName,
                        ReceiveMessageImage = y.UserInfo.Image!.Path,
                        IsYourMessage = y.UserInfo.UserId == _userContext.CurrentUserId,
                    })
                    .ToList(),
            })
            .FirstOrDefaultAsync(cancellationToken)
            ?? throw new ApplicationException("У данного пользователя не найден данный чат");
    }
}