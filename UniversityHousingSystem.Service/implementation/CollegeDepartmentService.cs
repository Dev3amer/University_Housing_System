using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
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



        public async Task<CollegeDepartment?> GetAsync(byte id)
        {
            return await _collegeDepartmentRepository.GetByIdAsync((byte)id); // Cast to int
        }

        //public async Task<CollegeDepartment?> GetAsync(byte id)
        //{
        //    return await _collegeDepartmentRepository.GetByIdAsync(id);
        //}
        //public async Task<CollegeDepartment> CreateAsync(CollegeDepartment newCollegeDepartment)
        //{
        //    return await _collegeDepartmentRepository.AddAsync(newCollegeDepartment);
        //}


        ///


        public async Task<CollegeDepartment> CreateAsync(CollegeDepartment collegeDepartment)
        {
            var college= await _collegeRepository.GetByIdAsync(collegeDepartment.CollegeId);
            if (college == null)
                throw new ArgumentException("Invalid CollegeId. College does not exist.");

            collegeDepartment.College=college;
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
        ////
       


        #endregion
    }
}
