using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class MediaFileConfiguration : IEntityTypeConfiguration<MediaFile>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<MediaFile> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(p => p.CreatedDate);
        builder.Property(p => p.UpdatedDate);
        builder.Property(p => p.CreatedBy);
        builder.Property(p => p.UpdatedBy);

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Path)
            .IsRequired();

        builder.Property(p => p.Size)
            .IsRequired();

        builder.HasOne(x => x.Game)
            .WithOne(y => y.MainImage);
    }
}