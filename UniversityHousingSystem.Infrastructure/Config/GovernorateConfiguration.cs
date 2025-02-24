using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class GovernorateConfiguration : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> builder)
        {
            builder.HasKey(g => g.GovernorateId);

            // Properties
            builder.Property(g => g.NameEn)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.NameAr)
                .IsRequired()
                .HasMaxLength(100);

            // Relationships
            builder.HasOne(g => g.Country)
                .WithMany(c => c.Governorates)
                .HasForeignKey(g => g.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Governorates");

            // Unique constraints for names within a country
            builder.HasIndex(g => new { g.CountryId, g.NameEn }).IsUnique();
            builder.HasIndex(g => new { g.CountryId, g.NameAr }).IsUnique();
        }
    }
}
