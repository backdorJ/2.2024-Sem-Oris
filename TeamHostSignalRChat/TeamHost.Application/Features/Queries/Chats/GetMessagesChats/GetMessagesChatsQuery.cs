using MediatR;
using TeamHost.Application.Contracts.Chats.GetMessagesChats;

namespace TeamHost.Application.Features.Queries.Chats.GetMessagesChats;

/// <summary>
/// Запрос на получение сообщений чата
/// </summary>
public class GetMessagesChatsQuery : IRequest<GetMessagesChatsResponse>
{
    public GetMessagesChatsQuery(Guid chatId)
        => ChatId = chatId;
    
    /// <summary>
    /// ИД чата
    /// </summary>
    public Guid ChatId { get; set; }
}