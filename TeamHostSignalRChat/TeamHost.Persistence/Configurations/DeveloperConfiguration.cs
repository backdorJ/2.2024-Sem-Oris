using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class DeveloperConfiguration : IEntityTypeConfiguration<Developer>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Developer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.CreatedBy);

        builder.Property(p => p.UpdatedBy);

        builder.Property(p => p.CreatedDate);

        builder.Property(p => p.UpdatedDate);

        builder.Property(p => p.Name);

        builder.HasOne(x => x.Country)
            .WithMany(y => y.Developers)
            .HasForeignKey(x => x.CountryId)
            .HasPrincipalKey(y => y.Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(x => x.Games)
            .WithOne(y => y.Developer)
            .HasForeignKey(y => y.DeveloperId)
            .HasPrincipalKey(x => x.Id);
    }
}