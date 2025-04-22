using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class AttendanceService : IAttendanceService
    {
        #region Fields
        private readonly IAttendanceRepository _attendanceRepository;
        #endregion

        #region Contructors
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Attendance>> GetAllAsync()
        {
            return await _attendanceRepository.GetTableNoTracking()
                .Include(a => a.Student)
                .ToListAsync();
        }
        public IQueryable<Attendance> GetAllQueryable(DateTime? search)
        {

            var queryableList = _attendanceRepository.GetTableNoTracking()
               .Include(a => a.Student)
               .AsQueryable();

            if (search != null)
            {
                queryableList = queryableList.Where(a => a.DateAndTime == search);
            }

            queryableList = queryableList.OrderBy(m => m.DateAndTime);

            return queryableList;
        }
        public async Task<Attendance?> GetAsync(int id)
        {
            return await _attendanceRepository
                .GetTableNoTracking()
                .Include(a => a.Student)
                .FirstOrDefaultAsync(a => a.AttendanceId == id);
        }
        public async Task<Attendance> CreateAsync(Attendance newAttendance)
        {
            return await _attendanceRepository.AddAsync(newAttendance);
        }

        #endregion
    }
}
