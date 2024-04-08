using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Страна
/// </summary>
public class Country : BaseAuditableEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Числовой код страны
    /// </summary>
    public int Code { get; set; }

    /// <summary>
    /// 2х-буквенный код
    /// </summary>
    public string? AplhaTwo { get; set; }

    /// <summary>
    /// 3х-буквенный код
    /// </summary>
    public string? AplhaThree { get; set; }

    /// <summary>
    /// Компании
    /// </summary>
    public ICollection<Developer> Developers { get; set; } = new List<Developer>();

    /// <summary>
    /// Пользователи
    /// </summary>
    public ICollection<UserInfo> Users { get; set; } = new List<UserInfo>();
}