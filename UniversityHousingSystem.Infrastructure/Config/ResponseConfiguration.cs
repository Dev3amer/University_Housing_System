using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class ResponseConfiguration : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.HasKey(r => r.ResponseId);

            // Response Date configuration
            builder.Property(r => r.ResponseAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Relationships
            builder.HasOne(r => r.Student)
                .WithMany(s => s.Responses)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Questionnaire)
                .WithMany(q => q.Responses)
                .HasForeignKey(r => r.QuestionnaireId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Responses");

            // Unique constraint to prevent multiple responses from same student for same questionnaire
            builder.HasIndex(r => new { r.StudentId, r.QuestionnaireId })
                .IsUnique()
                .HasDatabaseName("IX_Response_Student_Questionnaire");
        }
    }
}
