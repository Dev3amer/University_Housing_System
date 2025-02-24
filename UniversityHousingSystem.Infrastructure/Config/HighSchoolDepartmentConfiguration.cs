using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class HighSchoolDepartmentConfiguration : IEntityTypeConfiguration<HighSchoolDepartment>
    {
        public void Configure(EntityTypeBuilder<HighSchoolDepartment> builder)
        {
            builder.HasKey(hsd => hsd.HighSchoolDepartmentId);

            // Properties
            builder.Property(hsd => hsd.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Relationship
            builder.HasOne(hsd => hsd.HighSchool)
                .WithMany(hs => hs.HighSchoolDepartment)
                .HasForeignKey(hsd => hsd.HighSchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("HighSchoolDepartments");

            // Unique constraint for department name within a high school
            builder.HasIndex(hsd => new { hsd.HighSchoolId, hsd.Name }).IsUnique();
        }
    }
}
