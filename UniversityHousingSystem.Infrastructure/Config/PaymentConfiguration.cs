using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Primary Key
            builder.HasKey(p => p.PaymentId);

            // Properties
            builder.Property(p => p.AmountPaid)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(p => p.PaymentDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasConversion<string>();

            // Relationship
            builder.HasOne(p => p.Invoice)
                .WithOne(i => i.Payment)
                .HasForeignKey<Payment>(p => p.InvoiceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // Table name
            builder.ToTable("Payments");

            // Indexes
            builder.HasIndex(p => p.PaymentDate);
        }
    }
}
