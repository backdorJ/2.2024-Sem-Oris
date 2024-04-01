using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.UpdatedDate);
        builder.Property(p => p.CreatedDate);
        builder.Property(p => p.UpdatedBy);
        builder.Property(p => p.CreatedBy);
        builder.Property(p => p.Name)
            .IsRequired();

        builder.HasMany(x => x.Games)
            .WithMany(y => y.Categories);
    }
}