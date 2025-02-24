using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(q => q.QuestionId);

            // Properties
            builder.Property(q => q.Text)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(q => q.Type)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(q => q.IsRequired)
                .IsRequired();

            // Relationship
            builder.HasOne(q => q.Questionnaire)
                .WithMany(qn => qn.Questions)
                .HasForeignKey(q => q.QuestionnaireId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Questions");
        }
    }
}
