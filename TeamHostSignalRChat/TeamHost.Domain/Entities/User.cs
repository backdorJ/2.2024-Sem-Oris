using Microsoft.AspNetCore.Identity;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Сущнсоть пользователя
/// </summary>
public class User : IdentityUser<Guid>
{
    /// <summary>
    /// Инфа пользователя
    /// </summary>
    public UserInfo UserInfo { get; set; }
}