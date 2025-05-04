using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IStudentService
    {
        Task<Student?> GetAsync(int id);
        Task<Student?> GetByQrTextAsync(string qrText);
        Task<bool> DeleteAsync(Student student);
    }
}
