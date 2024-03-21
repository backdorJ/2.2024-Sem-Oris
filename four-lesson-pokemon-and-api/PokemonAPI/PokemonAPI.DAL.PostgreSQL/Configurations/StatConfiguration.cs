using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonAPI.Core.Entities;

namespace PokemonAPI.DAL.PostgreSQL.Configurations;

/// <summary>
/// Конфигурация для статистики
/// </summary>
public class StatConfiguration : IEntityTypeConfiguration<Stat>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Stat> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Value)
            .IsRequired();

        builder.HasOne(x => x.Poke)
            .WithMany(y => y.Statistic)
            .HasForeignKey(x => x.PokemonId)
            .HasPrincipalKey(y => y.Id);
    }
}