using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class StudentsNotificationsConfiguration : IEntityTypeConfiguration<StudentsNotifications>
    {
        public void Configure(EntityTypeBuilder<StudentsNotifications> builder)
        {
            builder.HasKey(sn => new { sn.StudentId, sn.NotificationId });

            builder.HasOne(sn => sn.Student)
            .WithMany(s => s.StudentsNotifications)
            .HasForeignKey(sn => sn.StudentId);

            builder.HasOne(sn => sn.Notification)
                .WithMany(n => n.StudentsNotifications)
                .HasForeignKey(sn => sn.NotificationId);


            builder.Property(sn => sn.IsRead)
                .HasDefaultValue(false);

            builder.ToTable("StudentsNotifications");
        }
    }
}
