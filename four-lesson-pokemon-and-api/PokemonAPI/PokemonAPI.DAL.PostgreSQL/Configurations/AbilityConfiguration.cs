using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entities;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

/// <summary>
/// Конфигурация способности
/// </summary>
public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Ability> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasMany(x => x.Pokemons)
            .WithMany(y => y.Abilities);
    }
}