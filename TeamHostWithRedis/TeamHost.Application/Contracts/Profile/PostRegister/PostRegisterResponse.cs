namespace TeamHost.Application.Contracts.Profile.PostRegister;

public class PostRegisterResponse
{
    /// <summary>
    /// Успешно ли
    /// </summary>
    public bool IsSucceed { get; set; }

    /// <summary>
    /// Ошибки
    /// </summary>
    public List<string>? Errors { get; set; }
}