using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entities;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

public class MoveConfiguration : IEntityTypeConfiguration<Move>

{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Move> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasMany(x => x.Pokemons)
            .WithMany(y => y.Moves);
    }
}