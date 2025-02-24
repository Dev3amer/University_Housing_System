using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmployeeId);

            // Properties
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(e => e.SecondName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(e => e.ThirdName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(e => e.FourthName)
                .IsRequired()
                .HasMaxLength(55);

            // Relationship
            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Employees");

            // Index for full name searches
            builder.HasIndex(e => new { e.FirstName, e.SecondName, e.ThirdName, e.FourthName });
        }
    }
}
