using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Компания
/// </summary>
public class Developer : BaseAuditableEntity
{
    /// <summary>
    /// Имя разраба
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// ИД страны
    /// </summary>
    public Guid? CountryId { get; set; }
    
    /// <summary>
    /// Nav prop
    /// </summary>
    public Country? Country { get; set; }

    /// <summary>
    /// Игры компании
    /// </summary>
    public ICollection<Game> Games { get; set; } = new List<Game>();
}