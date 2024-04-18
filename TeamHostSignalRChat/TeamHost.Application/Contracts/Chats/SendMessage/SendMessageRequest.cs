namespace TeamHost.Application.Contracts.Chats.SendMessage;

/// <summary>
/// Запрос на отправку сообщения
/// </summary>
public class SendMessageRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public SendMessageRequest()
    {
    }
    
    /// <summary>
    /// Конструтор
    /// </summary>
    /// <param name="request">Запрос</param>
    public SendMessageRequest(SendMessageRequest request)
    {
        Message = request.Message;
    }
    
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; } = default!;
}