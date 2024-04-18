using Microsoft.EntityFrameworkCore;
using TeamHost.Domain.Entities;
using TeamHost.Domain.Entities.Chats;

namespace TeamHost.Application.Interfaces;

public interface IDbContext
{
    /// <summary>
    /// Категории
    /// </summary>
    public DbSet<Category> Categories { get; set; }
    
    /// <summary>
    /// Страны
    /// </summary>
    public DbSet<Country> Countries { get; set; }
    
    /// <summary>
    /// Компании
    /// </summary>
    public DbSet<Developer> Developers { get; set; }
    
    /// <summary>
    /// Игры
    /// </summary>
    public DbSet<Game> Games { get; set; }
    
    /// <summary>
    /// Файлы
    /// </summary>
    public DbSet<MediaFile> MediaFiles { get; set; }
    
    /// <summary>
    /// Пользователи
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Информация о пользователе
    /// </summary>
    public DbSet<UserInfo> UserInfos { get; set; }

    /// <summary>
    /// Чаты
    /// </summary>
    public DbSet<Chat> Chats { get; set; }

    /// <summary>
    /// Сообщения
    /// </summary>
    public DbSet<Messages> Messages { get; set; }

    /// <summary>
    /// Метод сохранения
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}