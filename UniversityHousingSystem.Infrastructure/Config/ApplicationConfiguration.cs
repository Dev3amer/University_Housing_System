using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.ApplicationId);

            // Properties
            builder.Property(a => a.SubmitDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(a => a.AIValidationStatus)
                .IsRequired()
                .HasDefaultValue(EnStatus.Pending)
                .HasConversion<string>();

            builder.Property(a => a.FinalStatus)
                .IsRequired()
                .HasDefaultValue(EnStatus.Pending)
                .HasConversion<string>();

            builder.Property(a => a.AdminNotes)
                .HasMaxLength(500);

            builder.ToTable("Applications");

            // Indexes
            builder.HasIndex(a => a.SubmitDate);
            builder.HasIndex(a => a.AIValidationStatus);
            builder.HasIndex(a => a.FinalStatus);
        }
    }
}
