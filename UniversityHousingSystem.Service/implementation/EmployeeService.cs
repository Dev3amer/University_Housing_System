using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class EmployeeService : IEmployeeService
    {
        #region Fields
        private readonly IEmployeeRepository _employeeRepository;
        #endregion

        #region Contructors
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetTableNoTracking()
                .Include(e => e.User)
                .ToListAsync();
        }
        public IQueryable<Employee> GetAllQueryable(string? search)
        {

            var queryableList = _employeeRepository.GetTableNoTracking()
               .Include(e => e.User)
               .AsQueryable();

            if (search != null)
            {
                queryableList = queryableList.Where(m => m.FirstName.Contains(search));
            }
            queryableList = queryableList.OrderBy(e => e.FirstName);

            return queryableList;
        }
        public async Task<Employee?> GetAsync(int id)
        {
            return await _employeeRepository
                .GetTableNoTracking()
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.EmployeeId == id);
        }
        public async Task<Employee> CreateAsync(Employee newEmployee)
        {
            newEmployee.FirstName = newEmployee.FirstName.Trim();
            newEmployee.SecondName = newEmployee.SecondName.Trim();
            newEmployee.ThirdName = newEmployee.ThirdName.Trim();
            newEmployee.FourthName = newEmployee.FourthName.Trim();

            return await _employeeRepository.AddAsync(newEmployee);
        }
        public async Task<Employee> UpdateAsync(Employee employeeToUpdate)
        {
            employeeToUpdate.FirstName = employeeToUpdate.FirstName.Trim();
            employeeToUpdate.SecondName = employeeToUpdate.SecondName.Trim();
            employeeToUpdate.ThirdName = employeeToUpdate.ThirdName.Trim();
            employeeToUpdate.FourthName = employeeToUpdate.FourthName.Trim();

            return await _employeeRepository.UpdateAsync(employeeToUpdate);
        }
        public async Task<bool> DeleteAsync(Employee employeeToDelete)
        {
            _employeeRepository.BeginTransaction();
            try
            {
                await _employeeRepository.DeleteAsync(employeeToDelete);
                _employeeRepository.Commit();
                return true;
            }
            catch
            {
                _employeeRepository.RollBack();
                return false;
            }
        }

        #endregion
    }
}
