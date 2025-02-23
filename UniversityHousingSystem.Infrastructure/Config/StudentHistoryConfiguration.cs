using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class StudentHistoryConfiguration : IEntityTypeConfiguration<StudentHistory>
    {
        public void Configure(EntityTypeBuilder<StudentHistory> builder)
        {
            builder.HasKey(sh => sh.StudentHistoryId);

            builder.Property(sh => sh.From)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");  // SQL Server syntax for UTC date

            builder.Property(sh => sh.To)
                .IsRequired(false);

            // Relationships
            builder.HasOne(sh => sh.Student)
                .WithMany(s => s.StudentHistories)
                .HasForeignKey(sh => sh.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("StudentHistories");

            // Add check constraint to ensure To date is after From date
            builder.ToTable(tb => tb.HasCheckConstraint(
                "CK_StudentHistory_ToDate_After_FromDate",
                "[To] IS NULL OR [To] > [From]"
            ));
        }
    }
}
