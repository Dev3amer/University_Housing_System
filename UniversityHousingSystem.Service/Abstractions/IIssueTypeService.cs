using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IIssueTypeService
    {
        Task<IEnumerable<IssueType>> GetAllAsync();
        Task<IssueType?> GetAsync(int id);
        Task<IssueType> CreateAsync(IssueType newIssueType);
        Task<IssueType> UpdateAsync(IssueType IssueTypeToUpdate);
        Task<bool> DeleteAsync(IssueType IssueTypeToDelete);
    }
}
