using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;
using TeamHost.Persistence.Configurations;

namespace TeamHost.Persistence.Context;

public class EfContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }

    /// <inheritdoc />
    public DbSet<Category> Categories { get; set; }

    /// <inheritdoc />
    public DbSet<Country> Countries { get; set; }

    /// <inheritdoc />
    public DbSet<Developer> Developers { get; set; }

    /// <inheritdoc />
    public DbSet<Game> Games { get; set; }

    /// <inheritdoc />
    public DbSet<MediaFile> MediaFiles { get; set; }

    /// <inheritdoc />
    public DbSet<UserInfo> UserInfos { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new DeveloperConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new MediaFileConfiguration());
        modelBuilder.ApplyConfiguration(new UserInfoConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}