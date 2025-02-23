using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class VisitConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            // Primary Key
            builder.HasKey(v => v.VisitId);

            // Properties configurations
            builder.Property(v => v.VisitId)
                .ValueGeneratedOnAdd();

            // Name properties
            builder.Property(v => v.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.SecondName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.ThirdName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.FourthName)
                .IsRequired()
                .HasMaxLength(50);

            // National ID
            builder.Property(v => v.NationalId)
                .IsRequired()
                .HasMaxLength(14)  // Adjust based on your country's National ID length
                .IsUnicode(false); // If National ID only contains numbers, set to false

            // Visit Date
            builder.Property(v => v.VisitDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            // Status Enum
            builder.Property(v => v.Status)
                .IsRequired()
                .HasDefaultValue(EnStatus.Pending)
                .HasConversion<string>();  // Store enum as string in database

            // Relationship with Student (Many Visits to One Student)
            builder.HasOne(v => v.Student)
                .WithMany(s => s.Visits)
                .HasForeignKey(v => v.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Table name
            builder.ToTable("Visits");

            // Indexes for better query performance
            builder.HasIndex(v => v.NationalId);
        }
    }
}
