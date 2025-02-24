using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class GuardianConfiguration : IEntityTypeConfiguration<Guardian>
    {
        public void Configure(EntityTypeBuilder<Guardian> builder)
        {
            builder.HasKey(g => g.GuardianId);

            // Properties
            builder.Property(g => g.FirstName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(g => g.SecondName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(g => g.ThirdName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(g => g.FourthName)
                .IsRequired()
                .HasMaxLength(55);

            builder.Property(g => g.Job)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.NationalId)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(g => g.Phone)
                .IsRequired()
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(g => g.GuardianRelation)
                .IsRequired()
                .HasMaxLength(50);

            builder.ToTable("Guardians");

            // Indexes
            builder.HasIndex(g => g.NationalId).IsUnique();
            builder.HasIndex(g => new { g.FirstName, g.SecondName, g.ThirdName, g.FourthName });
        }
    }
}
