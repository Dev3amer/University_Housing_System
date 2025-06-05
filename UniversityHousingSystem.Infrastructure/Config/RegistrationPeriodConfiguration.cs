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

            // Table name
            builder.ToTable("RegistrationPeriods");
        }
    }
}
