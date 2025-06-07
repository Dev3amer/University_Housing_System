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

            // Relationships
            builder.HasOne(ns => ns.HighSchool)
                .WithMany(hs => hs.NewStudents)
                .HasForeignKey(ns => ns.HighSchoolId)
                .OnDelete(DeleteBehavior.NoAction);


            builder.HasOne(os => os.Student)
                 .WithOne(s => s.NewStudent)
                 .OnDelete(DeleteBehavior.Cascade);


            builder.ToTable("NewStudents");
        }
    }
}
