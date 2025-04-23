using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IAttendanceService
    {
        Task<IEnumerable<Attendance>> GetAllAsync();
        IQueryable<Attendance> GetAllQueryable(DateTime? dateTime, string? studentNationalId);
        Task<Attendance?> GetAsync(int id);
        Task<Attendance> CreateAsync(Attendance newAttendance);
    }
}
