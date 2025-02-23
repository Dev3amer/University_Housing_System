using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.InvoiceId);

            // Properties configurations
            builder.Property(i => i.ForMonth)
                .IsRequired();

            builder.Property(i => i.RequiredAmount)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(i => i.DueDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(i => i.Status)
                .IsRequired()
                .HasDefaultValue(EnPaymentStatus.Pending)
                .HasConversion<string>();

            // Configure InvoiceType property
            builder.Property(i => i.InvoiceType)
                .IsRequired()
                .HasConversion<string>();

            // Relationships
            builder.HasOne(i => i.Student)
                .WithMany(s => s.Invoices)
                .HasForeignKey(i => i.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Invoices", tb =>
            {
                tb.HasCheckConstraint("CK_Invoice_ForMonth", "[ForMonth] BETWEEN 1 AND 12");
                tb.HasCheckConstraint("CK_Invoice_RequiredAmount", "[RequiredAmount] > 0");
            });

            // Indexes for better query performance
            builder.HasIndex(i => i.ForMonth);
            builder.HasIndex(i => i.Status);

            //Unique constraint for one invoice per student per month
            builder.HasIndex(i => new { i.StudentId, i.ForMonth, i.InvoiceType })
                .HasDatabaseName("IX_Invoice_Student_Month_Type");
        }
    }
}
