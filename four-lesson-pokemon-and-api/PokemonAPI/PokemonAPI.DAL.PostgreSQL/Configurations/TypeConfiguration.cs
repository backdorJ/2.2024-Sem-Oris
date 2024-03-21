using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Type = PokemonAPI.Core.Entities.Type;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

/// <summary>
/// Конфигурация типов
/// </summary>
public class TypeConfiguration : IEntityTypeConfiguration<Type>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Type> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasMany(x => x.Pokemons)
            .WithMany(y => y.Types);
    }
}