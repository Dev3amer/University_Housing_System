using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class NewStudentService : INewStudentService
    {
        #region Fields
        private readonly INewStudentRepository _newStudentRepository;
        #endregion

        #region Contructors
        public NewStudentService(INewStudentRepository newStudentRepository)
        {
            _newStudentRepository = newStudentRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<NewStudent>> GetAllAsync()
        {
            return await _newStudentRepository.GetTableNoTracking()
                .ToListAsync();
        }
        public IQueryable<NewStudent> GetAllQueryable(string? search, EnStudentOrdering? studentOrderingEnum)
        {

            var queryableList = _newStudentRepository.GetTableNoTracking()
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
        public async Task<NewStudent?> GetAsync(int id)
        {
            return await _newStudentRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(s => s.NewStudentId == id);
        }
        public async Task<NewStudent> CreateAsync(NewStudent newStudent)
        {
            newStudent.Student.FirstName = newStudent.Student.FirstName.Trim();
            newStudent.Student.SecondName = newStudent.Student.SecondName.Trim();
            newStudent.Student.ThirdName = newStudent.Student.ThirdName.Trim();
            newStudent.Student.FourthName = newStudent.Student.FourthName.Trim();

            newStudent.Student.PlaceOfBirth = newStudent.Student.PlaceOfBirth.Trim();
            newStudent.Student.AddressLine = newStudent.Student.AddressLine.Trim();
            newStudent.Student.StudentQR = Guid.NewGuid().ToString();


            return await _newStudentRepository.AddAsync(newStudent);
        }
        public async Task<NewStudent> UpdateAsync(NewStudent newStudentToUpdate)
        {
            newStudentToUpdate.Student.FirstName = newStudentToUpdate.Student.FirstName.Trim();
            newStudentToUpdate.Student.SecondName = newStudentToUpdate.Student.SecondName.Trim();
            newStudentToUpdate.Student.ThirdName = newStudentToUpdate.Student.ThirdName.Trim();
            newStudentToUpdate.Student.FourthName = newStudentToUpdate.Student.FourthName.Trim();

            newStudentToUpdate.Student.PlaceOfBirth = newStudentToUpdate.Student.PlaceOfBirth.Trim();
            newStudentToUpdate.Student.AddressLine = newStudentToUpdate.Student.AddressLine.Trim();

            return await _newStudentRepository.UpdateAsync(newStudentToUpdate);
        }
        public async Task<bool> DeleteAsync(NewStudent newStudentToDelete)
        {
            _newStudentRepository.BeginTransaction();
            try
            {
                await _newStudentRepository.DeleteAsync(newStudentToDelete);
                _newStudentRepository.Commit();
                return true;
            }
            catch
            {
                _newStudentRepository.RollBack();
                return false;
            }
        }
        #endregion
    }
}
