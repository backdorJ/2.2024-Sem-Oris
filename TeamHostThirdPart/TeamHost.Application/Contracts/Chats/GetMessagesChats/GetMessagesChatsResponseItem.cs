namespace TeamHost.Application.Contracts.Chats.GetMessagesChats;

/// <summary>
/// Элмент сообщения для <see cref="GetMessagesChatsResponse"/>
/// </summary>
public class GetMessagesChatsResponseItem
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Отрпавить сообщения
    /// </summary>
    public string? ReceiveMessageName { get; set; }

    /// <summary>
    /// Фото отправителя
    /// </summary>
    public string? ReceiveMessageImage { get; set; }

    /// <summary>
    /// Твои ли сообщение
    /// </summary>
    public bool IsYourMessage { get; set; }
}