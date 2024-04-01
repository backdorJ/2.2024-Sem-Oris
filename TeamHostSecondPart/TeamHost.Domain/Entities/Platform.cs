using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Platform : BaseEntity
{
    /// <summary>
    /// Назавние
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Код
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// Фото
    /// </summary>
    public MediaFile? MediaFile { get; set; }

    /// <summary>
    /// Игры
    /// </summary>
    public ICollection<Game> Games { get; set; } = new List<Game>();
}   