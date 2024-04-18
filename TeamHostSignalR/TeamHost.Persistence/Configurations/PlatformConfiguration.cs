using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class PlatformConfiguration : IEntityTypeConfiguration<Platform>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Platform> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Name);

        builder.Property(p => p.Code);

        builder.HasMany(x => x.Games)
            .WithMany(y => y.Platforms);
    }
}