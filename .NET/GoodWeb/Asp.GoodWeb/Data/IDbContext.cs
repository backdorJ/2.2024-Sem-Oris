using Asp.GoodWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.GoodWeb.Data;

public interface IDbContext
{
    /// <summary>
    /// Пользаки
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Схранение
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}