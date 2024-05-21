namespace Good.API.Services.Hasher;

public interface IHasherPassword
{
    public string HashPassword(string password);

    public bool VerifyPassword(string password, string hashPassword);
}