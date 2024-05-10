using Microsoft.AspNetCore.Http;

namespace TeamHost.Application.Contracts.Profile.EditProfile;

public class EditProfileRequest
{
    public EditProfileRequest()
    {
    }

    public EditProfileRequest(EditProfileRequest request)
    {
        FirstName = request.FirstName;
        LastName = request.LastName;
        Patronymic = request.Patronymic;
        About = request.About;
        Birthday = request.Birthday;
        Country = request.Country;
        ProfileImage = request.ProfileImage;
    }
    
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    /// Информауия о себе
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Фото профиля
    /// </summary>
    public IFormFile? ProfileImage { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Guid? Country { get; set; }
}