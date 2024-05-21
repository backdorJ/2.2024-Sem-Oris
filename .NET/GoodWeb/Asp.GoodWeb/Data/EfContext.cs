using Asp.GoodWeb.Entities;
using Microsoft.EntityFrameworkCore;

namespace Asp.GoodWeb.Data;

public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    public DbSet<User> Users { get; set; }
}