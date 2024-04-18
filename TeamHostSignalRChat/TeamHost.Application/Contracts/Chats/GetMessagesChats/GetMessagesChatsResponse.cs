namespace TeamHost.Application.Contracts.Chats.GetMessagesChats;

public class GetMessagesChatsResponse
{
    /// <summary>
    /// Название чата
    /// </summary>
    public string? ChatTitle { get; set; }

    /// <summary>
    /// Картинка чата
    /// </summary>
    public string? ChatImage { get; set; }

    /// <summary>
    /// ИД чата
    /// </summary>
    public Guid ChatId { get; set; }

    /// <summary>
    /// Это группа
    /// </summary>
    public bool IsGroup { get; set; }

    /// <summary>
    /// Информация о сообщении
    /// </summary>
    public List<GetMessagesChatsResponseItem>? Messages { get; set; }
}