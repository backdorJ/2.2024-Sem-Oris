using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities.Chats;

public class Chat : BaseEntity
{
    /// <summary>
    /// Название чата
    /// </summary>
    public string? TitleChat { get; set; }
    
    /// <summary>
    /// Картинка
    /// </summary>
    public MediaFile? MediaFile { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public List<Messages> Messages { get; set; }
    
    /// <summary>
    /// Информвуия о пользователя
    /// </summary>
    public List<UserInfo> UserInfos { get; set; }
}