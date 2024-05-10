using MediatR;
using TeamHost.Application.Contracts.Chats.SendMessage;

namespace TeamHost.Application.Features.Queries.Chats.SendMessage;

/// <summary>
/// Команда на отправку сообщения
/// </summary>
public class SendMessageCommand : SendMessageRequest, IRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="chatId">ИД чата</param>
    /// <param name="request">Запрос</param>
    public SendMessageCommand(Guid chatId, SendMessageRequest request)
        : base(request)
        => ChatId = chatId;
    
    /// <summary>
    /// ИД чата
    /// </summary>
    public Guid ChatId { get; set; }
}