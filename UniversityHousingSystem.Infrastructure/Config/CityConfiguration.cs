using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            // Properties
            builder.Property(c => c.NameEn)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.NameAr)
                .IsRequired()
                .HasMaxLength(50);

            // Relationship
            builder.HasOne(c => c.Governorate)
                .WithMany(g => g.Cities)
                .HasForeignKey(c => c.GovernorateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Cities");

            // Unique constraints for names within a governorate
            builder.HasIndex(c => new { c.GovernorateId, c.NameEn }).IsUnique();
            builder.HasIndex(c => new { c.GovernorateId, c.NameAr }).IsUnique();
        }
    }
}
