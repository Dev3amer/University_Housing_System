using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class RegistrationPeriodConfiguration : IEntityTypeConfiguration<RegistrationPeriod>
    {
        public void Configure(EntityTypeBuilder<RegistrationPeriod> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(r => r.Students)
                .WithOne(s => s.RegistrationPeriod)
                .HasForeignKey(s => s.RegistrationPeriodId)
                .OnDelete(DeleteBehavior.Cascade);

            // Table name
            builder.ToTable("RegistrationPeriods");
        }
    }
}
