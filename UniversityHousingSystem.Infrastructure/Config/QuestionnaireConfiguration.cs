using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class QuestionnaireConfiguration : IEntityTypeConfiguration<Questionnaire>
    {
        public void Configure(EntityTypeBuilder<Questionnaire> builder)
        {
            builder.HasKey(q => q.QuestionnaireId);

            // Properties
            builder.Property(q => q.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(q => q.Description)
                .HasMaxLength(500);

            builder.Property(q => q.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(q => q.ForYear)
                .IsRequired();

            // Relationship
            builder.HasOne(q => q.Employee)
                .WithMany(e => e.Questionnaires)
                .HasForeignKey(q => q.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Questionnaires");

            // Indexes
            builder.HasIndex(q => q.ForYear);
        }
    }
}
