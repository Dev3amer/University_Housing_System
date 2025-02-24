using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class HighSchoolConfiguration : IEntityTypeConfiguration<HighSchool>
    {
        public void Configure(EntityTypeBuilder<HighSchool> builder)
        {
            builder.HasKey(hs => hs.HighSchoolId);

            // Properties
            builder.Property(hs => hs.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("HighSchools");

            // Unique constraint for high school name
            builder.HasIndex(hs => hs.Name).IsUnique();
        }
    }
}
