using TeamHost.Domain.Entities;

namespace TeamHost.Application.Contracts.Profile.GetUserById;

/// <summary>
/// Ответ на запрос пользователя
/// </summary>
public class GetUserByIdResponse
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }
    
    /// <summary>
    /// Др
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Обо мне
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Country? Country { get; set; }
}