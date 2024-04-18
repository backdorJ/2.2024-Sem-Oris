using MediatR;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Contracts.Chats.GetChats;
using TeamHost.Application.Interfaces;

namespace TeamHost.Application.Features.Queries.Chats.GetChats;

public class GetChatsQueryHandler : IRequestHandler<GetChatsQuery, List<GetChatsResponse>>
{
    private readonly IUserContext _userContext;
    private readonly IDbContext _dbContext;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="userContext">Контекст пользователя</param>
    /// <param name="dbContext">Контекст пользователя</param>
    public GetChatsQueryHandler(IUserContext userContext, IDbContext dbContext)
    {
        _userContext = userContext;
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task<List<GetChatsResponse>> Handle(GetChatsQuery request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        return await _dbContext.Chats
            .Where(x => x.UserInfos.Any(y => y.UserId == _userContext.CurrentUserId))
            .GroupJoin(_dbContext.Messages,
                chat => chat.Id,
                message => message.ChatId,
                (chat, messages) => new 
                    { 
                        Chat = chat,
                        Messages = messages
                            .OrderByDescending(m => m.CreatedDate)
                            .FirstOrDefault()
                    })
            .OrderByDescending(result => result!.Messages!.CreatedDate)
            .Select(result => new GetChatsResponse
            {
                IsGroup = result.Chat.UserInfos.Count() > 2,
                ChatId = result.Chat.Id,
                FriendId = result.Chat.UserInfos.Count() > 2
                    ? null
                    : result.Chat.UserInfos
                        .FirstOrDefault(x => x.UserId != _userContext.CurrentUserId)!.UserId,
                TitleChat = result.Chat.UserInfos.Count() > 2
                    ? result.Chat.TitleChat
                    : result.Chat.UserInfos
                        .FirstOrDefault(y => y.UserId != _userContext.CurrentUserId)!.User!.UserName,
                LastSend = result.Messages != null ? result.Messages.CreatedDate : null,
                Image = result.Chat.UserInfos.Count() > 2
                    ? result.Chat.MediaFile!.Path
                    : result.Chat.UserInfos
                        .FirstOrDefault(x => x.UserId != _userContext.CurrentUserId)!
                        .Image!.Path,
                LastReceivedMessage = result.Messages != null ? result.Messages.Message : null,
            })
            .ToListAsync(cancellationToken);
    }
}