using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class CollegeService : ICollegeService
    {
        #region Fields
        private readonly ICollegeRepository _collegeRepository;
        private readonly AppDbContext _db;
        #endregion

        #region Contructors
        public CollegeService(ICollegeRepository collegeRepository, AppDbContext db)
        {
            _collegeRepository = collegeRepository;
            _db = db;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<College>> GetAllAsync()
        {
            return _collegeRepository.GetTableNoTracking();
        }




        public async Task<College?> GetAsync(int id)
        {
            var college = await _collegeRepository.GetByIdAsync(id);
            return college;
        }

        public async Task<College> CreateAsync(College newCollege)
        {
            return await _collegeRepository.AddAsync(newCollege);
        }
        //colege with dept
        //public async Task<College> CreateAsync(College newCollege)
        //{
        //    // Check if there are departments to add
        //    if (newCollege.Departments != null && newCollege.Departments.Any())
        //    {
        //        foreach (var dept in newCollege.Departments)
        //        {
        //            dept.CollegeId = newCollege.CollegeId;  // Ensure FK is set
        //        }
        //    }

        //    var createdCollege = await _collegeRepository.AddAsync(newCollege);
        //    return createdCollege;
        //}


        public async Task<College> UpdateAsync(College collegeToUpdate)
        {
            return await _collegeRepository.UpdateAsync(collegeToUpdate);
        }

        public async Task<bool> DeleteAsync(College collegeToDelete)
        {
            await _collegeRepository.DeleteAsync(collegeToDelete);
            return true;
        }
        ////
       


        #endregion
    }
}
