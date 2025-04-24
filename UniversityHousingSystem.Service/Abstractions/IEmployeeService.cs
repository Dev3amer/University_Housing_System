using UniversityHousingSystem.Data.Entities;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        IQueryable<Employee> GetAllQueryable(string? search);
        Task<Employee?> GetAsync(int id);
        Task<Employee> CreateAsync(Employee newEmployee);
        Task<Employee> UpdateAsync(Employee employeeToUpdate);
        Task<bool> DeleteAsync(Employee employeeToDelete);
    }
}
