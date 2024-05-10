using TeamHost.Domain.Common;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Сущность информации о пользователи
/// </summary>
public class UserInfo : BaseEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string? Patronimic { get; set; }

    /// <summary>
    /// Информауия о себе
    /// </summary>
    public string? About { get; set; }

    /// <summary>
    /// День рождения
    /// </summary>
    public DateTime? Birthday { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Country? Country { get; set; }

    /// <summary>
    /// ИД страны
    /// </summary>
    public Guid? CountryId { get; set; }

    /// <summary>
    /// ИД картинки
    /// </summary>
    public Guid? ImageId { get; set; }

    /// <summary>
    /// nav-prop
    /// </summary>
    public MediaFile? Image { get; set; }
    
    /// <summary>
    /// Nav-prop
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// ИД пользователя
    /// </summary>
    public Guid? UserId { get; set; }

    /// <summary>
    /// Чаты
    /// </summary>
    public List<Chat> Chats { get; set; }

    /// <summary>
    /// Обновить информацию
    /// </summary>
    public void UpdateInfo(
        string firstName,
        string lastName,
        string? patronomic,
        string? about,
        DateTime? birthday,
        Country? country,
        MediaFile? image)
    {
        FirstName = firstName;
        LastName = lastName;
        Patronimic = patronomic ?? Patronimic;
        About = about ?? About;
        Birthday = birthday ?? Birthday;
        Country = country ?? Country;
        Image = image ?? Image;
    }
}