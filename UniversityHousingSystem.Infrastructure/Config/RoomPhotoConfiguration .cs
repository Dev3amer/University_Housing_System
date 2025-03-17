using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{

    public class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhoto>
    {
        public void Configure(EntityTypeBuilder<RoomPhoto> builder)
        {
            // Primary Key
            builder.HasKey(rp => rp.RoomPhotoId);

            // Properties configurations
            builder.Property(rp => rp.PhotoPath)
                   .IsRequired()
                   .HasColumnType("nvarchar(255)");

            // Foreign key relationship
            builder.HasOne(rp => rp.Room)
                   .WithMany(r => r.RoomPhotos)
                   .HasForeignKey(rp => rp.RoomId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("RoomPhotos");
        }
    }
}
