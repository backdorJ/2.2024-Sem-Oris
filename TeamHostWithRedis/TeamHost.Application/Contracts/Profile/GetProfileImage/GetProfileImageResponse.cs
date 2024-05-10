namespace TeamHost.Application.Contracts.Profile.GetProfileImage;

public class GetProfileImageResponse
{
    /// <summary>
    /// Путь к картинке
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// ИД текущего пользователя
    /// </summary>
    public Guid? CurrentUserId { get; set; }
}