using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class CollegeDepartmentConfiguration : IEntityTypeConfiguration<CollegeDepartment>
    {
        public void Configure(EntityTypeBuilder<CollegeDepartment> builder)
        {
            builder.HasKey(cd => cd.CollegeDepartmentId);

            // Properties
            builder.Property(cd => cd.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            builder.HasOne(cd => cd.College)
                .WithMany(c => c.Departments)
                .HasForeignKey(cd => cd.CollegeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("CollegeDepartments");

            // Unique constraint for department name within a college
            builder.HasIndex(cd => new { cd.CollegeId, cd.Name }).IsUnique();
        }
    }
}
