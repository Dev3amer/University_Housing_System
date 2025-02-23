using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(i => i.IssueId);

            // Properties configurations
            builder.Property(i => i.Description)
                .IsRequired()
                .HasMaxLength(2500);

            builder.Property(i => i.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(i => i.ResponseDate)
                .IsRequired(false);

            builder.Property(i => i.Response)
                .IsRequired(false)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(i => i.IssueType)
                .WithMany(it => it.Issues)
                .HasForeignKey(i => i.IssueTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Student)
                .WithMany(s => s.Issues)
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Employee)
                .WithMany(e => e.Issues)
                .HasForeignKey(i => i.EmployeeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Issues");
        }
    }
}
