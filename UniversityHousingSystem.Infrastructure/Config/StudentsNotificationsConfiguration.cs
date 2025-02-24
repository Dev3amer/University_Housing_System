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

            builder.ToTable("StudentsNotifications");
        }
    }
}
