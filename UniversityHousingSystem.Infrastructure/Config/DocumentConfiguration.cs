using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            // Primary Key
            builder.HasKey(d => d.DocumentId);

            // Properties
            builder.Property(d => d.Path)
                .IsRequired()
                .HasMaxLength(2500);

            // Relationships 
            builder.HasOne(d => d.Student)
                .WithMany(s => s.Documents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Store enum as string
            builder.Property(d => d.DocumentType)
                  .IsRequired()
                  .HasMaxLength(55)
                  .HasConversion(
                      v => v.ToString(),
                      v => (EnDocumentType)Enum.Parse(typeof(EnDocumentType), v)
                  );

            builder.ToTable("Documents");
        }
    }
}
