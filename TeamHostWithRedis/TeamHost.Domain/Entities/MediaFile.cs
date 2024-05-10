using TeamHost.Domain.Common;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Файлы для игры
/// </summary>
public class MediaFile : BaseAuditableEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string? Name { get; set; }
    
    /// <summary>
    /// Путь
    /// </summary>
    public string? Path { get; set; }

    /// <summary>
    /// Размер
    /// </summary>
    public ulong Size { get; set; }

    /// <summary>
    /// Игра
    /// </summary>
    public Game? Game { get; set; }

    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public UserInfo? UserInfo { get; set; }
    
    /// <summary>
    /// Чаты
    /// </summary>
    public List<Chat> Chats { get; set; }
}