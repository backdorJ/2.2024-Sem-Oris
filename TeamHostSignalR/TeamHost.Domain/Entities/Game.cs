using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Игра
/// </summary>
public class Game : BaseAuditableEntity
{
    /// <summary>
    /// Название игры
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Цена
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Краткое описание
    /// </summary>
    public string? ShortDescription { get; set; }

    /// <summary>
    /// Рейтинг
    /// </summary>
    public float Rating { get; set; }

    /// <summary>
    /// Дата релиза
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// ИД компании
    /// </summary>
    public Guid DeveloperId { get; set; }
    
    /// <summary>
    /// Компания
    /// </summary>
    public Developer? Developer { get; set; }

    /// <summary>
    /// ИД фотки
    /// </summary>
    public Guid MainImageId { get; set; }
    
    /// <summary>
    /// Первая фотка
    /// </summary>
    public MediaFile? MainImage { get; set; }

    /// <summary>
    /// Платформы
    /// </summary>
    public ICollection<Platform> Platforms { get; set; }

    /// <summary>
    /// Файлы
    /// </summary>
    public ICollection<MediaFile> MediaFiles { get; set; } = new List<MediaFile>();

    /// <summary>
    /// Категории
    /// </summary>
    public ICollection<Category> Categories { get; set; } = new List<Category>();
}