using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

public class Category : BaseAuditableEntity
{
    /// <summary>
    /// Название категории
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Игры
    /// </summary>
    public ICollection<Game> Games { get; set; } = new List<Game>();
}