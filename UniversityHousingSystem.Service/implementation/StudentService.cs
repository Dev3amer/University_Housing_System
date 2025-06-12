using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Contructors
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                _studentRepository.Commit();
                return true;
            }
            catch
            {
                _studentRepository.RollBack();
                return false;
            }
        }
        #endregion

        #region Methods
        public async Task<Student?> GetAsync(int id)
        {
            return await _studentRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(a => a.StudentId == id);
        }

        public async Task<Student?> GetByQrTextAsync(string qrText)
        {
            return await _studentRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(a => a.QRText == qrText);
        }

        public async Task<IEnumerable<Student>> GetTopStudents(int MaleStudentsNumber, int FemaleStudentsNumber, int RegistrationPeriodId)
        {
            var baseQuery = _studentRepository.GetTableAsTracking()
                        .Include(s => s.Application)
                        .Where(s => s.RegistrationPeriodId == RegistrationPeriodId);

            var topMales = await baseQuery
                .Where(s => s.Gender == EnGender.Male)
                .OrderByDescending(s => s.CurrentScore)
                .Take(MaleStudentsNumber)
                .ToListAsync();

            var topFemales = await baseQuery
                .Where(s => s.Gender == EnGender.Female)
                .OrderByDescending(s => s.CurrentScore)
                .Take(FemaleStudentsNumber)
                .ToListAsync();

            return topMales.Concat(topFemales);
        }

        public async Task UpdateStudents(IEnumerable<Student> topStudents)
        {
            await _studentRepository.UpdateRangeAsync(topStudents);
        }
        #endregion
    }
}
