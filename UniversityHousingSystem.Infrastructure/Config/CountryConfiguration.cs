using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(c => c.CountryId);

            // Properties
            builder.Property(c => c.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.NameAr)
                .IsRequired()
                .HasMaxLength(100);

            builder.ToTable("Countries");

            // Unique constraints for names
            builder.HasIndex(c => c.NameEn).IsUnique();
            builder.HasIndex(c => c.NameAr).IsUnique();
        }
    }
}
