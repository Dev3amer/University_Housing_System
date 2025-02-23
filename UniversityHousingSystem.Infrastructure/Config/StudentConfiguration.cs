using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Infrastructure.Config
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            #region PersonalInformation
            builder.Property(s => s.FirstName)
                  .IsRequired()
                  .HasMaxLength(55);

            builder.Property(s => s.SecondName)
                  .IsRequired()
                  .HasMaxLength(55);

            builder.Property(s => s.ThirdName)
                  .IsRequired()
                  .HasMaxLength(55);

            builder.Property(s => s.FourthName)
                  .IsRequired()
                  .HasMaxLength(55);

            builder.Property(s => s.NationalId)
                  .IsRequired()
                  .HasMaxLength(20);

            builder.Property(s => s.Phone)
                  .IsRequired()
                  .HasMaxLength(13);

            builder.Property(s => s.Telephone)
                  .HasMaxLength(15);

            builder.Property(s => s.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(s => s.Gender)
                .IsRequired()
                .HasMaxLength(10)
                .HasConversion(
                    v => v.ToString(),
                    v => (EnGender)Enum.Parse(typeof(EnGender), v)
                );

            builder.Property(s => s.Religion)
                .IsRequired()
                .HasMaxLength(20)
                .HasConversion(
                v => v.ToString(),
                v => (EnReligion)Enum.Parse(typeof(EnReligion), v)
                );

            builder.Property(s => s.PlaceOfBirth)
                  .IsRequired()
                  .HasMaxLength(100);

            #endregion


            #region Academic-Information
            builder.Property(s => s.AcademicStudentCode)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(s => s.AcademicYear)
                  .HasColumnType("tinyint")
                  .IsRequired();

            builder.Property(s => s.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            builder.Property(s => s.AddressLine)
                  .IsRequired()
                  .HasMaxLength(200);

            builder.Property(s => s.StudentQR)
                  .HasMaxLength(200);
            #endregion

            #region One-to-One

            builder.HasOne(s => s.Application)
                .WithOne(a => a.Student)
                .HasForeignKey<Student>(s => s.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.User)
                  .WithOne(u => u.Student)
                  .HasForeignKey<Student>(s => s.UserId)
                  .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.OldStudent)
                 .WithOne(o => o.Student)
                 .HasForeignKey<Student>(s => s.OldStudentId)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.NewStudent)
                  .WithOne(n => n.Student)
                  .HasForeignKey<Student>(s => s.NewStudentId)
                  .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region One-to-Many
            builder.HasOne(s => s.Guardian)
                  .WithMany(g => g.Students)
                  .HasForeignKey(s => s.GuardianId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Village)
                  .WithMany(v => v.Students)
                  .HasForeignKey(s => s.ResidencePlace)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Country)
                  .WithMany(c => c.Students)
                  .HasForeignKey(s => s.CountryId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.College)
                  .WithMany(c => c.Students)
                  .HasForeignKey(s => s.CollegeId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Room)
                  .WithMany(r => r.Students)
                  .HasForeignKey(s => s.RoomId)
                  .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region Many-To-Many
            builder.HasMany(s => s.Notifications)
                  .WithMany(n => n.Students)
                  .UsingEntity<StudentsNotifications>();
            #endregion

            #region Indexes
            builder.HasIndex(s => s.NationalId).IsUnique();
            builder.HasIndex(s => s.Email).IsUnique();
            builder.HasIndex(s => s.AcademicStudentCode).IsUnique();
            #endregion

            builder.ToTable("Students");
        }
    }
}
