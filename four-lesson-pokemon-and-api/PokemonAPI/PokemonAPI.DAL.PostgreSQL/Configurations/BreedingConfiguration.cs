using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entities;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

public class BreedingConfiguration : IEntityTypeConfiguration<Breeding>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Breeding> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Weight)
            .IsRequired();

        builder.Property(p => p.Height)
            .IsRequired();

        builder.HasOne(x => x.Pokemon)
            .WithOne(y => y.Breeding);
    }
}