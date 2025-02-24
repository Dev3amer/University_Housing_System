using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Infrastructure.Config.Identity
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {

            builder.Property(u => u.ResetCode)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(2000)
                .IsRequired(false);
        }
    }
}
