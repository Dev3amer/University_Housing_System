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
                  .HasMaxLength(13)
                  .IsUnicode(false);

            //builder.Property(s => s.Telephone)
            //      .HasMaxLength(15)
            //      .IsUnicode(false);

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

            //builder.Property(s => s.PlaceOfBirth)
            //      .IsRequired()
            //      .HasMaxLength(100);

            #endregion


            #region Academic-Information
            builder.Property(s => s.AcademicStudentCode)
                  .IsRequired()
                  .HasMaxLength(50);

            builder.Property(s => s.AcademicYear)
                  .IsRequired()
                  .HasMaxLength(25);

            builder.Property(s => s.Email)
                  .IsRequired()
                  .HasMaxLength(100);

            //builder.Property(s => s.AddressLine)
            //      .IsRequired()
            //      .HasMaxLength(200);

            builder.Property(s => s.QRText)
                  .HasMaxLength(255);

            builder.Property(s => s.QRImagePath)
                  .HasMaxLength(2500)
                  .IsRequired(false);
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

            builder.HasOne(s => s.CollegeDepartment)
                  .WithMany(cd => cd.Students)
                  .HasForeignKey(s => s.CollegeDepartmentId)
                  .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Indexes
            builder.HasIndex(e => new { e.FirstName, e.SecondName, e.ThirdName, e.FourthName });
            builder.HasIndex(s => s.NationalId).IsUnique();
            builder.HasIndex(s => s.Email).IsUnique();
            builder.HasIndex(s => s.AcademicStudentCode).IsUnique();
            #endregion


            builder.ToTable("Students");
        }
    }
}
