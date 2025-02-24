using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.HasKey(o => o.OptionId);

            // Properties
            builder.Property(o => o.Text)
                .IsRequired()
                .HasMaxLength(500);

            // Relationship
            builder.HasOne(o => o.Question)
                .WithMany(q => q.Options)
                .HasForeignKey(o => o.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Collection of Answers
            builder.HasMany(o => o.Answers)
                .WithOne(a => a.Option)
                .HasForeignKey(a => a.OptionId)
                .IsRequired(false)  // Answer might not have an option (for text questions)
                .OnDelete(DeleteBehavior.SetNull);// If option is deleted, set null in answers

            builder.ToTable("Options");

            // option text should be unique within a question
            builder.HasIndex(o => new { o.QuestionId, o.Text })
                .IsUnique()
                .HasDatabaseName("IX_Option_Question_Text");
        }
    }
}
