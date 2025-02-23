using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.AttendanceId);

            // Properties configurations
            builder.Property(a => a.DateAndTime)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(a => a.EntryType)
                .IsRequired()
                .HasConversion<string>();

            // Relationships
            builder.HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Attendances");
        }
    }
}
