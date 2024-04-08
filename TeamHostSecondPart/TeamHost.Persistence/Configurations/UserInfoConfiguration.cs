using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamHost.Domain.Entities;

namespace TeamHost.Persistence.Configurations;

public class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.FirstName)
            .IsRequired();

        builder.Property(p => p.LastName)
            .IsRequired();

        builder.Property(p => p.Patronimic);
        
        builder.Property(p => p.Birthday);

        builder.Property(p => p.About);

        builder.HasOne(x => x.Country)
            .WithMany(y => y.Users)
            .HasForeignKey(x => x.CountryId)
            .HasPrincipalKey(y => y.Id)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasOne(x => x.User)
            .WithOne(y => y.UserInfo)
            .HasForeignKey<UserInfo>(x => x.UserId)
            .HasPrincipalKey<User>(y => y.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}