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

            // Relationships (Document has both StudentId and DocTypeId FKs)
            builder.HasOne(d => d.Student)
                .WithMany(s => s.Documents)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.DocumentType)
                .WithMany(dt => dt.Documents)
                .HasForeignKey(d => d.DocTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Documents");
        }
    }
}
