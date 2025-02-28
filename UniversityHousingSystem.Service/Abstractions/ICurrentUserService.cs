using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface ICurrentUserService
    {
        Task<ApplicationUser> GetUserAsync();
        string GetUserId();
        Task<bool> CheckIfRuleExist(string roleName);
    }
}
