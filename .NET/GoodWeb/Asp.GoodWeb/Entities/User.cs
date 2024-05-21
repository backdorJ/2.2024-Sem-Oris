namespace Asp.GoodWeb.Entities;

public class User
{
    /// <summary>
    /// ИД
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// E-mail
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Хеш
    /// </summary>
    public string HashPassword { get; set; }

    public static User CreateUser(
        string username,
        string email,
        string hash)
        => new User
        {
            Username = username,
            Email = email,
            HashPassword = hash
        };
}