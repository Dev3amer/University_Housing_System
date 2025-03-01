using UniversityHousingSystem.Data.Entities.Identity;

namespace UniversityHousingSystem.Service.Abstractions
{
    public interface IUserService
    {
        Task<ApplicationUser> CreateUser(ApplicationUser user, string password);
        Task SendConfirmUserEmailToken(ApplicationUser user);
        Task ConfirmUserEmail(ApplicationUser user, string code);
        Task<bool> SendResetUserPasswordCode(string email);
        Task<bool> ValidatePasswordResetCode(string email, string code);
        Task ResetUserPassword(string email, string newPassword);
    }
}
