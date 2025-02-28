using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class NewStudentConfiguration : IEntityTypeConfiguration<NewStudent>
    {
        public void Configure(EntityTypeBuilder<NewStudent> builder)
        {
            builder.HasKey(ns => ns.NewStudentId);

            // Properties configurations
            builder.Property(ns => ns.HighSchoolPercentage)
                .HasPrecision(5, 2)
                .IsRequired();

            builder.Property(ns => ns.IsOutsideSchool)
                .IsRequired();

            // Relationships
            builder.HasOne(ns => ns.HighSchool)
                .WithMany(hs => hs.NewStudents)
                .HasForeignKey(ns => ns.HighSchoolId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("NewStudents");
        }
    }
}
