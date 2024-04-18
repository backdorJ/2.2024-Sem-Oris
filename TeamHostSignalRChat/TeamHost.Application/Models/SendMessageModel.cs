namespace TeamHost.Application.Models;

public class SendMessageModel
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// Твое сообщение
    /// </summary>
    public bool IsYourMessage { get; set; }
    
    /// <summary>
    /// Кому рассылать
    /// </summary>
    public List<Guid?>? SentTo { get; set; }

    /// <summary>
    /// Отправитель
    /// </summary>
    public Guid? WhoSentId { get; set; }

    /// <summary>
    /// Картинки пользователей
    /// </summary>
    public Dictionary<Guid?, string?> Images { get; set; }

    /// <summary>
    /// Имя отправителя
    /// </summary>
    public string? SenderName { get; set; }
}