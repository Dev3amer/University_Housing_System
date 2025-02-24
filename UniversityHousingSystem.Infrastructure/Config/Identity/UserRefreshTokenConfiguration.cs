using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Infrastructure.Config.Identity
{
    public class UserRefreshTokenConfiguration : IEntityTypeConfiguration<UserRefreshToken>
    {
        public void Configure(EntityTypeBuilder<UserRefreshToken> builder)
        {
            builder.HasKey(u => u.Id);


            builder.HasOne(ur => ur.User)
                .WithMany(u => u.UserRefreshTokens)
                .HasForeignKey(u => u.UserId);

            builder.ToTable("UserRefreshTokens");
        }
    }
}
