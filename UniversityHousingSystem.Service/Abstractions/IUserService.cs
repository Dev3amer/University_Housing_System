using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Helpers.DTOs;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IUserService
    {
        Task<CreateUserResult> CreateUser(ApplicationUser user, string password, string role);
        Task SendConfirmUserEmailToken(ApplicationUser user);
        Task ConfirmUserEmail(ApplicationUser user, string code);
        Task<bool> SendResetUserPasswordCode(string email);
        Task<bool> ValidatePasswordResetCode(string email, string code);
        Task ResetUserPassword(string email, string newPassword);
    }
}
