namespace TeamHost.Application.Contracts.Chats.GetChats;

/// <summary>
/// Ответ на запрос получения всех чатов
/// </summary>
public class GetChatsResponse
{
    /// <summary>
    /// ИД чата
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Группа ли
    /// </summary>
    public bool IsGroup { get; set; }
    
    /// <summary>
    /// Название чата
    /// </summary>
    public string? TitleChat { get; set; }

    /// <summary>
    /// Время последней отправки
    /// </summary>
    public DateTime? LastSend { get; set; }

    /// <summary>
    /// Картинка чата
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Последнее сообщение
    /// </summary>
    public string? LastReceivedMessage { get; set; }

    /// <summary>
    /// Ид собеседника
    /// </summary>
    public Guid? FriendId { get; set; }
}