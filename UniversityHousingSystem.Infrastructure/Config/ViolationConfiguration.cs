using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class ViolationConfiguration : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.HasKey(v => v.ViolationId);

            // Properties
            builder.Property(v => v.ViolationDate)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(v => v.ViolationType)
                .WithMany(vt => vt.Violations)
                .HasForeignKey(v => v.ViolationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(v => v.StudentHistory)
                .WithMany(sh => sh.Violations)
                .HasForeignKey(v => v.StudentHistoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Violations");
        }
    }
}
