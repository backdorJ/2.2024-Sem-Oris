namespace Asp.GoodWeb.Contracts.Contracts.Auth.Register;

public class RegisterRequest
{
    public RegisterRequest()
    {
    }

    public RegisterRequest(RegisterRequest request)
    {
        Username = request.Username;
        Email = request.Email;
        Password = request.Password;
        ConfirmPassword = request.ConfirmPassword;
    }

    /// <summary>
    /// Имя
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Повтор пароля
    /// </summary>
    public string ConfirmPassword { get; set; }
}