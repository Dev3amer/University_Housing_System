using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IStudentHousingService
    {
        void AssignStudentsToRooms(IEnumerable<Student> acceptedStudents, ICollection<Room> allRooms);
    }
}
