using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class CollegeDepartmentService : ICollegeDepartmentService
    {
        #region Fields
        private readonly ICollegeDepartmentRepository _collegeDepartmentRepository;
        private readonly ICollegeRepository _collegeRepository;
        #endregion

        #region Contructors
        public CollegeDepartmentService(ICollegeDepartmentRepository collegeDepartmentRepository, ICollegeRepository collegeRepository)
        {
            _collegeDepartmentRepository = collegeDepartmentRepository;
            _collegeRepository = collegeRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<CollegeDepartment>> GetAllAsync()
        {
            return _collegeDepartmentRepository.GetTableNoTracking();
        }

        public async Task<CollegeDepartment?> GetAsync(int id)
        {
            return await _collegeDepartmentRepository.GetByIdAsync(id);
        }
        public async Task<CollegeDepartment> CreateAsync(CollegeDepartment collegeDepartment)
        {
            var college = await _collegeRepository.GetByIdAsync(collegeDepartment.CollegeId);
            if (college == null)
                throw new ArgumentException("Invalid CollegeId. College does not exist.");

            collegeDepartment.College = college;
            return await _collegeDepartmentRepository.AddAsync(collegeDepartment);
        }
        public async Task<CollegeDepartment?> GetLastCollegeDepartmentAsync()
        {
            return await _collegeDepartmentRepository.GetTableAsTracking()
                .OrderByDescending(cd => cd.CollegeDepartmentId)
                .FirstOrDefaultAsync();
        }



        public async Task<CollegeDepartment> UpdateAsync(CollegeDepartment collegeDepartmentToUpdate)
        {
            return await _collegeDepartmentRepository.UpdateAsync(collegeDepartmentToUpdate);
        }

        public async Task<bool> DeleteAsync(CollegeDepartment collegeDepartmentToDelete)
        {
            await _collegeDepartmentRepository.DeleteAsync(collegeDepartmentToDelete);
            return true;
        }

        public async Task<IEnumerable<CollegeDepartment>> GetAllDepartmentsByCollegeId(int collegeId)
        {
            return await _collegeDepartmentRepository.GetTableNoTracking()
                .Where(cd => cd.CollegeId == collegeId)
                .ToListAsync();
        }
        ////



        #endregion
    }
}
