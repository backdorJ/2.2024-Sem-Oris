using TeamHost.Domain.Common;

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
}