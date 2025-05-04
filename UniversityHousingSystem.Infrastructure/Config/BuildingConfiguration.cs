using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(b => b.BuildingId);

            // Properties configurations
            builder.Property(b => b.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.AddressInDetails)
                .HasColumnType("nvarchar")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(b => b.MapIFrame)
                .HasColumnType("nvarchar")
                .HasMaxLength(2500)
                .IsRequired(false);

            // Store enum as string
            builder.Property(b => b.Type)
                  .IsRequired()
                  .HasMaxLength(50)
                  .HasConversion(
                      v => v.ToString(),  // Convert enum to string when saving
                      v => (EnBuildingType)Enum.Parse(typeof(EnBuildingType), v) // Convert string back to enum when reading
                  );

            // Foreign key relationship
            builder.HasOne(b => b.Village)
                  .WithMany(v => v.Buildings)
                  .HasForeignKey(b => b.VillageId)
                  .OnDelete(DeleteBehavior.Restrict);


            // Navigation property configuration
            builder.HasMany(b => b.Rooms)
                  .WithOne(r => r.Building)
                  .HasForeignKey(b => b.BuildingId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Buildings");
        }
    }
}
