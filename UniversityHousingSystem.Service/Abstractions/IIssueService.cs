using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IIssueService
    {
        Task<IEnumerable<Issue>> GetAllAsync();
        Task<Issue?> GetAsync(int id);
        Task<Issue> CreateAsync(Issue issue);
        Task<Issue> UpdateAsync(Issue issueToUpdate);
        Task<bool> DeleteAsync(Issue issueToDelete);

    }
}
