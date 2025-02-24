using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class ViolationTypeConfiguration : IEntityTypeConfiguration<ViolationType>
    {
        public void Configure(EntityTypeBuilder<ViolationType> builder)
        {
            builder.HasKey(vt => vt.ViolationTypeId);

            // Properties
            builder.Property(vt => vt.Description)
                .HasMaxLength(500);

            builder.Property(vt => vt.ViolationLevel)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(vt => vt.RequiredAmount)
                .HasPrecision(10, 2);

            builder.ToTable("ViolationTypes");
        }
    }
}
