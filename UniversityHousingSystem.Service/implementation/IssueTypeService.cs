using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities;
using UniversityHousingSystem.Data.Helpers.Enums;
using UniversityHousingSystem.Infrastructure.implementation;
using UniversityHousingSystem.Infrastructure.Repositories;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Implementation
{
    public class IssueTypeService : IIssueTypeService
    {
        #region Fields
        private readonly IIssueTypeRepository _issueTypeRepository;
        #endregion

        #region Constructors
        public IssueTypeService(IIssueTypeRepository issueTypeRepository )
        {
            _issueTypeRepository = issueTypeRepository;             
        }
        #endregion

        #region Methods

        public async Task<IEnumerable<IssueType>> GetAllAsync()
        {
            return await _issueTypeRepository.GetTableNoTracking().ToListAsync();
               
        }

       

       public async Task<IssueType> GetAsync(int id)
        {
            return await _issueTypeRepository.GetTableNoTracking()
               .Include(i => i.Issues)
               .FirstOrDefaultAsync(i => i.IssueTypeId == id);
        }

        public async Task<IssueType> CreateAsync(IssueType newIssueType)
        {
            return await _issueTypeRepository.AddAsync(newIssueType);
        }

        public async Task<IssueType> UpdateAsync(IssueType IssueTypeToUpdate)
        {
            return await _issueTypeRepository.UpdateAsync(IssueTypeToUpdate);
        }
        public async Task<bool> DeleteAsync(IssueType IssueTypeToDelete)
        {
            await _issueTypeRepository.DeleteAsync(IssueTypeToDelete);
            return true;
        }

        #endregion
    }
}
