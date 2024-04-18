using TeamHost.Domain.Entities;

namespace TeamHost.Application.Contracts.Profile.PostRegister;

/// <summary>
/// Запрос на регистрацию пользователя
/// </summary>
public class PostRegisterRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public PostRegisterRequest()
    {
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostRegisterRequest(PostRegisterRequest request)
    {
        Username = request.Username;
        Email = request.Email;
        Password = request.Password;
    }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// Email пользователя
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}