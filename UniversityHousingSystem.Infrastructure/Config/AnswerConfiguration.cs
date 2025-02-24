using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => a.AnswerId);

            // Properties
            builder.Property(a => a.AnswerText)
                .HasMaxLength(1000);  // Adjust based on your needs

            // Relationships
            builder.HasOne(a => a.Response)
                .WithMany(r => r.Answers)
                .HasForeignKey(a => a.ResponseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Question)
                .WithOne(q => q.Answer)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Option)
                .WithMany(o => o.Answers)
                .HasForeignKey(a => a.OptionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Answers");

            builder.HasIndex(a => new { a.ResponseId, a.QuestionId })
                .IsUnique()
                .HasDatabaseName("IX_Answer_Response_Question");
        }
    }
}
