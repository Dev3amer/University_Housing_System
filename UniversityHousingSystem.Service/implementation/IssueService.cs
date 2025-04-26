using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class IssueService : IIssueService
    {
        #region Fields
        private readonly IIssueRepository _iIssueRepository;
        private readonly IIssueTypeRepository _iIssueTypeRepository;
        #endregion

        #region Contructors
        public IssueService(IIssueRepository iIssueRepository, IIssueTypeRepository iIssueTypeRepository)
        {

            _iIssueRepository = iIssueRepository;
            _iIssueTypeRepository = iIssueTypeRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Issue>> GetAllAsync()
        {
            return _iIssueRepository.GetTableNoTracking();
        }

        public async Task<Issue?> GetAsync(int id)
        {
            return await _iIssueRepository.GetTableAsTracking()
                .Include(e=>e.Employee)
                .Include(i=>i.IssueType)
                .Include(s=>s.Student)
                .FirstOrDefaultAsync(i => i.IssueId == id);

        }
        public async Task<Issue> CreateAsync(Issue issue)
        {
            var issueType= await _iIssueTypeRepository.GetByIdAsync(issue.IssueTypeId);
            if (issueType == null)
                throw new ArgumentException("Invalid Issuetype. IssueType does not exist.");

            issue.IssueType=issueType;
            return await _iIssueRepository.AddAsync(issue);
        }
       



        public async Task<Issue> UpdateAsync(Issue IssueToUpdate)
        {
            return await _iIssueRepository.UpdateAsync(IssueToUpdate);
        }

        public async Task<bool> DeleteAsync(Issue issueToDelete)
        {
            await _iIssueRepository.DeleteAsync(issueToDelete);
            return true;
        }       
        #endregion
    }
}
