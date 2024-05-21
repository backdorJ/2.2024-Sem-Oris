namespace Asp.GoodWeb.Contracts.Contracts.Auth.Login;

public class LoginRequest
{
    public LoginRequest()
    {
    }
    
    public LoginRequest(LoginRequest request)
    {
        Email = request.Email;
        Password = request.Password;
    }
    
    /// <summary>
    /// Email
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; } = default!;
}