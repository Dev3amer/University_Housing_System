using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class OldStudentService : IOldStudentService
    {
        #region Fields
        private readonly IOldStudentRepository _oldStudentRepository;
        #endregion

        #region Contructors
        public OldStudentService(IOldStudentRepository oldStudentRepository)
        {
            _oldStudentRepository = oldStudentRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<OldStudent>> GetAllAsync()
        {
            return await _oldStudentRepository.GetTableNoTracking()
                .ToListAsync();
        }
        public IQueryable<OldStudent> GetAllQueryable(string? search, EnStudentOrdering? studentOrderingEnum)
        {

            var queryableList = _oldStudentRepository.GetTableNoTracking()
               .AsQueryable();

            if (search != null)
            {
                queryableList = queryableList.Where(os => os.Student.NationalId.Contains(search));
            }

            switch (studentOrderingEnum)
            {
                case EnStudentOrdering.FirstName:
                    queryableList = queryableList.OrderBy(os => os.Student.FirstName);
                    break;
                case EnStudentOrdering.CollegeId:
                    queryableList = queryableList.OrderByDescending(os => os.Student.CollegeId);
                    break;
                default:
                    queryableList = queryableList.OrderBy(os => os.Student.FirstName);
                    break;
            }

            return queryableList;
        }
        public async Task<OldStudent?> GetAsync(int id)
        {
            return await _oldStudentRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(s => s.OldStudentId == id);
        }
        public async Task<OldStudent> CreateAsync(OldStudent oldStudent)
        {
            oldStudent.Student.FirstName = oldStudent.Student.FirstName.Trim();
            oldStudent.Student.SecondName = oldStudent.Student.SecondName.Trim();
            oldStudent.Student.ThirdName = oldStudent.Student.ThirdName.Trim();
            oldStudent.Student.FourthName = oldStudent.Student.FourthName.Trim();

            oldStudent.Student.PlaceOfBirth = oldStudent.Student.PlaceOfBirth.Trim();
            oldStudent.Student.AddressLine = oldStudent.Student.AddressLine.Trim();
            oldStudent.Student.StudentQR = Guid.NewGuid().ToString();


            return await _oldStudentRepository.AddAsync(oldStudent);
        }
        public async Task<OldStudent> UpdateAsync(OldStudent oldStudentToUpdate)
        {
            oldStudentToUpdate.Student.FirstName = oldStudentToUpdate.Student.FirstName.Trim();
            oldStudentToUpdate.Student.SecondName = oldStudentToUpdate.Student.SecondName.Trim();
            oldStudentToUpdate.Student.ThirdName = oldStudentToUpdate.Student.ThirdName.Trim();
            oldStudentToUpdate.Student.FourthName = oldStudentToUpdate.Student.FourthName.Trim();

            oldStudentToUpdate.Student.PlaceOfBirth = oldStudentToUpdate.Student.PlaceOfBirth.Trim();
            oldStudentToUpdate.Student.AddressLine = oldStudentToUpdate.Student.AddressLine.Trim();

            return await _oldStudentRepository.UpdateAsync(oldStudentToUpdate);
        }
        public async Task<bool> DeleteAsync(OldStudent oldStudentToDelete)
        {
            _oldStudentRepository.BeginTransaction();
            try
            {
                await _oldStudentRepository.DeleteAsync(oldStudentToDelete);
                _oldStudentRepository.Commit();
                return true;
            }
            catch
            {
                _oldStudentRepository.RollBack();
                return false;
            }
        }
        #endregion
    }
}
