using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityHousingSystem.Data.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public int CountryId { get; set; }
        public string NationalID { get; set; }
        public string Phone { get; set; }
        public string Telephone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string PlaceOfBirth { get; set; }
        public bool HasSpecialNeeds { get; set; }
        public int GuardianID { get; set; }
        public string StudentCode { get; set; }
        public byte AcademicYear { get; set; }
        public int CollegeID { get; set; }
        public string Email { get; set; }
        public int ApplicationID { get; set; }
        public int ResidencePlace { get; set; }
        public bool IsMarried { get; set; }
        public string AddressLine { get; set; }
        public int RoomID { get; set; }
        public string UserID { get; set; }
        public int HistoryId { get; set; }
        public int? OldStudentId { get; set; }
        public int? NewStudentId { get; set; }
        public string StudentQR { get; set; }

        // Navigation Properties
        public Guardian Guardian { get; set; }
        public Village Village { get; set; }
        public Country Country { get; set; }
        public Issue Issue { get; set; }
        public College College { get; set; }
        public Application Application { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
        public StudentHistory History { get; set; }
        public OldStudent OldStudent { get; set; }
        public NewStudent NewStudent { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Visit> Visits { get; set; }
        // public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<StudentHistory> StudentHistorys { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
}
