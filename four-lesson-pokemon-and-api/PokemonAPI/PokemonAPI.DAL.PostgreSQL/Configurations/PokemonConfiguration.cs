using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entities;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

public class PokemonConfiguration : IEntityTypeConfiguration<Pokemon>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Pokemon> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.ImageUrl)
            .IsRequired();

        builder.Property(p => p.Order)
            .IsRequired();

        builder.HasMany(x => x.Statistic)
            .WithOne(y => y.Poke)
            .HasForeignKey(y => y.PokemonId)
            .HasPrincipalKey(x => x.Id);

        builder.HasMany(x => x.Abilities)
            .WithMany(y => y.Pokemons);

        builder.HasMany(x => x.Moves)
            .WithMany(y => y.Pokemons);
        
        builder.HasMany(x => x.Types)
            .WithMany(y =>  y.Pokemons);
    }
}