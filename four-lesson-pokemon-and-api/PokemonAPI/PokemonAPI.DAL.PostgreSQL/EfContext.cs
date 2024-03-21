using Microsoft.EntityFrameworkCore;
using PokemonAPI.Core.Abstractions;
using PokemonAPI.Core.Entities;
using PokemonAPI.DAL.PostgreSQL.Configurations;
using Type = PokemonAPI.Core.Entities.Type;

namespace PokemonAPI.DAL.PostgreSQL;

/// <summary>
/// Контекст БД
/// </summary>
public class EfContext : DbContext, IDbContext
{
    public EfContext(DbContextOptions<EfContext> options)
        : base (options)
    {
    }
    
    /// <inheritdoc />
    public DbSet<Ability> Abilities { get; set; } = null!;

    /// <inheritdoc />
    public DbSet<Breeding> Breeding { get; set; } = null!;

    /// <inheritdoc />
    public DbSet<Move> Moves { get; set; } = null!;

    /// <inheritdoc />
    public DbSet<Pokemon> Pokemons { get; set; } = null!;

    /// <inheritdoc />
    public DbSet<Stat> Stats { get; set; } = null!;

    /// <inheritdoc />
    public DbSet<Type> Types { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PokemonConfiguration());
        modelBuilder.ApplyConfiguration(new StatConfiguration());
        modelBuilder.ApplyConfiguration(new BreedingConfiguration());
        modelBuilder.ApplyConfiguration(new AbilityConfiguration());
        modelBuilder.ApplyConfiguration(new MoveConfiguration());
        modelBuilder.ApplyConfiguration(new TypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}