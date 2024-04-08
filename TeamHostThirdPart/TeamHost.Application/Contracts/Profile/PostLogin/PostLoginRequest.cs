namespace TeamHost.Application.Contracts.Profile.PostLogin;

public class PostLoginRequest
{
    /// <summary>
    /// Конструктор
    /// </summary>
    public PostLoginRequest()
    {
    }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="request">Запрос</param>
    public PostLoginRequest(PostLoginRequest request)
    {
        Username = request.Username;
        Password = request.Password;
    }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Username { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}