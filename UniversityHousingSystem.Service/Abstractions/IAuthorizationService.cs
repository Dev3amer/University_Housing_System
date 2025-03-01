using Microsoft.AspNetCore.Identity;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IAuthorizationService
    {
        Task<IdentityRole> CreateRoleAsync(string roleName);
        Task<IdentityRole> EditRoleAsync(string Id, string roleName);
        Task<bool> IsRoleExistByIdAsync(string Id);
        Task<IdentityResult> DeleteRoleAsync(string Id);
        Task<IEnumerable<IdentityRole>> GetAllRolesAsync();
        Task<IdentityRole> GetRoleByIdAsync(string id);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<List<string>> UpdateUserRolesAsync(string userId, List<string> rolesNames);
    }
}
