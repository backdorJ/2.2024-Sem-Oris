using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.Chats;

/// <summary>
/// Сущность сообщений
/// </summary>
public class Messages : BaseAuditableEntity
{
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; } = default!;

    /// <summary>
    /// Чат
    /// </summary>
    public Chat Chat { get; set; }

    /// <summary>
    /// ИД чата
    /// </summary>
    public Guid ChatId { get; set; }
    
    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid? UserInfoId { get; set; }

    /// <summary>
    /// nav-prop
    /// </summary>
    public UserInfo? UserInfo { get; set; }
}