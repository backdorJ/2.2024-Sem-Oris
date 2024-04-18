using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.CreatedBy);
        
        builder.Property(p => p.UpdatedBy);

        builder.Property(p => p.CreatedDate);

        builder.Property(p => p.UpdatedDate);

        builder.Property(p => p.Code)
            .HasMaxLength(4);

        builder.Property(p => p.AplhaTwo)
            .HasMaxLength(2);

        builder.Property(p => p.AplhaThree)
            .HasMaxLength(3);

        builder.HasMany(x => x.Developers)
            .WithOne(y => y.Country)
            .HasForeignKey(y => y.CountryId)
            .HasPrincipalKey(x => x.Id)
            .OnDelete(DeleteBehavior.SetNull);
    }
}