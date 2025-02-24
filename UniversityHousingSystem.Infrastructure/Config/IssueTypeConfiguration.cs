using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class IssueTypeConfiguration : IEntityTypeConfiguration<IssueType>
    {
        public void Configure(EntityTypeBuilder<IssueType> builder)
        {
            builder.HasKey(it => it.IssueTypeId);

            // Properties
            builder.Property(it => it.TypeName)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("IssueTypes");

            // Unique constraint for type name
            builder.HasIndex(it => it.TypeName).IsUnique();
        }
    }
}
