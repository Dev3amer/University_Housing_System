using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class VillageConfiguration : IEntityTypeConfiguration<Village>
    {
        public void Configure(EntityTypeBuilder<Village> builder)
        {
            builder.HasKey(v => v.VillageId);

            // Properties
            builder.Property(v => v.NameEn)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(v => v.NameAr)
                .IsRequired()
                .HasMaxLength(150);

            // Relationship
            builder.HasOne(v => v.City)
                .WithMany(c => c.Villages)
                .HasForeignKey(v => v.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Villages");

            // Unique constraints for names within a city
            builder.HasIndex(v => new { v.CityId, v.NameEn }).IsUnique();
            builder.HasIndex(v => new { v.CityId, v.NameAr }).IsUnique();
        }
    }
}
