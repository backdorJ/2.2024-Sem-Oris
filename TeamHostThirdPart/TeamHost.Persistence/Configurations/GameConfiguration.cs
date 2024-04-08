using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.Description);

        builder.Property(p => p.Rating)
            .HasDefaultValue(0);

        builder.Property(p => p.ReleaseDate);

        builder.Property(p => p.CreatedBy);

        builder.Property(p => p.UpdatedBy);

        builder.Property(p => p.CreatedDate);

        builder.Property(p => p.UpdatedDate);

        builder.Property(p => p.ShortDescription);

        builder.HasOne(p => p.MainImage)
            .WithOne(x => x.Game);
        
        builder.HasOne(x => x.Developer)
            .WithMany(y => y.Games)
            .HasForeignKey(x => x.DeveloperId)
            .HasPrincipalKey(y => y.Id);

        builder.HasMany(x => x.Categories)
            .WithMany(y => y.Games);
    }
}