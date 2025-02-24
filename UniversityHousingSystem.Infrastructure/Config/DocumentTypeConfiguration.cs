using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(dt => dt.DocumentTypeId);

            // Properties
            builder.Property(dt => dt.DocumentTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table name
            builder.ToTable("DocumentTypes");

            // Unique constraint for document type name
            builder.HasIndex(dt => dt.DocumentTypeName).IsUnique();
        }
    }
}
