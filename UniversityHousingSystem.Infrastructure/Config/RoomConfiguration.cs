using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            // Primary Key
            builder.HasKey(r => r.RoomId);

            // Properties configurations
            builder.Property(r => r.RoomNumber)
                .HasColumnType("nvarchar")
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(r => r.Price)
                  .IsRequired()
                  .HasColumnType("decimal")
                  .HasPrecision(18, 2);

            // Foreign key relationship
            builder.HasOne(r => r.Building)
                  .WithMany(b => b.Rooms)
                  .HasForeignKey(r => r.BuildingId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Navigation property configuration
            builder.HasMany(r => r.Students)
                  .WithOne(s => s.Room)
                  .HasForeignKey(r => r.RoomId)
                  .OnDelete(DeleteBehavior.Restrict);

            // Unique constraint for RoomNumber within a Building
            builder.HasIndex(r => new { r.BuildingId, r.RoomNumber })
                  .IsUnique();

            builder.ToTable("Rooms");
        }
    }
}
