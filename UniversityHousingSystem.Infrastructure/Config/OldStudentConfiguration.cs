using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class OldStudentConfiguration : IEntityTypeConfiguration<OldStudent>
    {
        public void Configure(EntityTypeBuilder<OldStudent> builder)
        {
            builder.HasKey(os => os.OldStudentId);

            // Properties configurations
            builder.Property(os => os.PreviousYearGrade)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(os => os.GradePercentage)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(os => os.PreviousYearHosting)
                .IsRequired();

            builder.ToTable("OldStudents");
        }
    }
}
