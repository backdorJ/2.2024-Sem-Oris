namespace Good.API.Services.Hasher;

public class HasherPassword : IHasherPassword
{
    /// <inheritdoc />
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    /// <inheritdoc />
    public bool VerifyPassword(string password, string hashPassword)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hashPassword);
}