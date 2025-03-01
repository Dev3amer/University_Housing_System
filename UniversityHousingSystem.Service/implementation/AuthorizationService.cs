using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        #endregion
        #region Constructor
        public AuthorizationService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, AppDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        #endregion
        #region Functions
        public async Task<IdentityRole> CreateRoleAsync(string roleName)
        {
            var role = new IdentityRole(roleName);
            var identityResult = await _roleManager.CreateAsync(role);

            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.FirstOrDefault().Description);

            role = await _roleManager.FindByNameAsync(roleName);
            return role;
        }

        public async Task<IdentityRole> EditRoleAsync(string Id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            role.Name = roleName;

            var identityResult = await _roleManager.UpdateAsync(role);
            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.FirstOrDefault().Description);
            }
            return role;
        }
        public async Task<IdentityResult> DeleteRoleAsync(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            if (users is not null && users.Count != 0)
                throw new Exception(string.Format(SharedResourcesKeys.DeleteRoleWithUsersException, new { role.Name, users.FirstOrDefault()?.UserName }));
            return await _roleManager.DeleteAsync(role);
        }

        public async Task<bool> IsRoleExistByIdAsync(string Id)
        {
            return await _roleManager.Roles.AnyAsync(r => r.Id == Id);
        }

        public async Task<IEnumerable<IdentityRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles
                .Select(r => new IdentityRole { Id = r.Id, Name = r.Name })
                .ToListAsync();
        }

        public async Task<IdentityRole> GetRoleByIdAsync(string id)
        {
            return await _roleManager.Roles
                .Select(r => new IdentityRole { Id = r.Id, Name = r.Name })
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception(SharedResourcesKeys.NotFound);

            var userRolesNames = await _userManager.GetRolesAsync(user);
            return userRolesNames.ToList();
        }

        public async Task<List<string>> UpdateUserRolesAsync(string userId, List<string> rolesNames)
        {
            var user = await _userManager.FindByIdAsync(userId) ?? throw new KeyNotFoundException(SharedResourcesKeys.NotFound);
            var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var oldUserRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, oldUserRoles);

                var identityResult = await _userManager.AddToRolesAsync(user, rolesNames);

                if (!identityResult.Succeeded)
                    throw new Exception(identityResult.Errors.FirstOrDefault().Description);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw ex;
            }
            return await GetUserRolesAsync(userId);
        }
        #endregion
    }
}
