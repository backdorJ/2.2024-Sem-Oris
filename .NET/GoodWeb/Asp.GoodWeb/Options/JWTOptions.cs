namespace Asp.GoodWeb.Options;

public class JWTOptions
{
    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Время жизни
    /// </summary>
    public long Expire { get; set; }

    /// <summary>
    /// Мы
    /// </summary>
    public string Issuer { get; set; }
}