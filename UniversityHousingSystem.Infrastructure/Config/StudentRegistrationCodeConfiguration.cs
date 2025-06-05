using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class StudentRegistrationCodeConfiguration : IEntityTypeConfiguration<StudentRegistrationCode>
    {
        public void Configure(EntityTypeBuilder<StudentRegistrationCode> builder)
        {
            builder.HasKey(c => c.Id);

            // Properties
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(c => c.Student)
            .WithOne(s => s.StudentRegistrationCode)
            .HasForeignKey<Student>(s => s.RegistrationCodeId)
            .OnDelete(DeleteBehavior.Cascade);

            // Table name
            builder.ToTable("RegistrationCodes");
        }
    }
}
