using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Data.Resources;
using UniversityHousingSystem.Infrastructure.Context;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class UserService : IUserService
    {
        #region Fields 
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmailService _emailService;
        private readonly IUrlHelper _urlHelper;
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructors
        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor, IEmailService emailService, IUrlHelper urlHelper, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _emailService = emailService;
            _urlHelper = urlHelper;
            _appDbContext = appDbContext;
        }
        #endregion
        public async Task SendConfirmUserEmailToken(ApplicationUser user)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var requestAccessor = _contextAccessor.HttpContext.Request;
            var urlActionContext = new UrlActionContext() { Action = "ConfirmEmail", Controller = "Users", Values = new { userId = user.Id, code } };
            var returnURL = requestAccessor.Scheme + "://" + requestAccessor.Host + _urlHelper.Action(urlActionContext);
            //var userFullName = user.FirstName + " " + user.LastName;
            var userFullName = "Dear";
            var message = $"<!DOCTYPE html>\r\n<html>\r\n  <head></head>\r\n  <body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; background-color: #f9f9f9; margin: 0; padding: 0;\">\r\n    <div style=\"max-width: 600px; margin: 20px auto; background: #ffffff; border: 1px solid #dddddd; border-radius: 8px; overflow: hidden;\">\r\n      <div style=\"background: #4caf50; color: #ffffff; text-align: center; padding: 20px;\">\r\n        <h2 style=\"margin: 0;\">Confirm Your Email</h2>\r\n      </div>\r\n      <div style=\"padding: 20px; text-align: left;\">\r\n        <h1 style=\"font-size: 24px; color: #4caf50; margin: 0;\">Hello, {userFullName}!</h1>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          Thank you for registering with us. Please confirm your email address to complete your registration and start using our services.\r\n        </p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">Click the button below to confirm your email address:</p>\r\n        <a href='{returnURL}' style=\"display: inline-block; padding: 10px 20px; margin-top: 20px; background: #4caf50; color: #ffffff; text-decoration: none; border-radius: 4px; font-size: 16px;\">Confirm Email</a>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          If the button above doesn't work, you can copy and paste the following link into your browser:\r\n        </p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\"><a href='{returnURL}' style=\"color: #4caf50; text-decoration: underline;\">[Confirmation Link]</a></p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          If you didn't create an account with us, please ignore this email.\r\n        </p>\r\n      </div>\r\n      <div style=\"background: #f1f1f1; text-align: center; padding: 10px; font-size: 12px; color: #555;\">\r\n        <p style=\"margin: 0;\">&copy; 2025 Cinema App. All rights reserved.</p>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>";
            await _emailService.SendEmail(user.Email, userFullName, message, "Confirm Email");
        }

        public async Task<ApplicationUser> CreateUser(ApplicationUser user, string password)
        {
            var identityResult = await _userManager.CreateAsync(user, password);

            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.FirstOrDefault().Description);

            user = await _userManager.FindByNameAsync(user.UserName);

            await _userManager.AddToRoleAsync(user, "User");

            await SendConfirmUserEmailToken(user);
            return user;
        }

        public async Task ConfirmUserEmail(ApplicationUser user, string code)
        {
            if (user.EmailConfirmed == true)
                throw new Exception(SharedResourcesKeys.EmailAlreadyConfirmed);

            var identityResult = await _userManager.ConfirmEmailAsync(user, code);

            if (!identityResult.Succeeded)
                throw new Exception(identityResult.Errors.FirstOrDefault().Description);
        }

        public async Task<bool> SendResetUserPasswordCode(string email)
        {
            //Get User
            var user = await _userManager.FindByEmailAsync(email) ?? throw new Exception(SharedResourcesKeys.EmailNotFound);

            var transaction = _appDbContext.Database.BeginTransaction();

            //Generate Random Code & insert it in User Row
            var randomCode = new Random().Next(0, 1000000).ToString("D6");
            user.ResetCode = HashCode(randomCode);
            var identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                transaction.Rollback();
                return false;
            }

            //var userFullName = user.FirstName + " " + user.LastName;
            var userFullName = "Dear";
            var message = $"<!DOCTYPE html>\r\n<html>\r\n  <head></head>\r\n  <body style=\"font-family: Arial, sans-serif; line-height: 1.6; color: #333; background-color: #f9f9f9; margin: 0; padding: 0;\">\r\n    <div style=\"max-width: 600px; margin: 20px auto; background: #ffffff; border: 1px solid #dddddd; border-radius: 8px; overflow: hidden;\">\r\n      <div style=\"background: #4caf50; color: #ffffff; text-align: center; padding: 20px;\">\r\n        <h2 style=\"margin: 0;\">Reset Your Password</h2>\r\n      </div>\r\n      <div style=\"padding: 20px; text-align: left;\">\r\n        <h1 style=\"font-size: 24px; color: #4caf50; margin: 0;\">Hello, {userFullName}!</h1>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          You requested to reset your password. Use the code below to reset it:\r\n        </p>\r\n        <div style=\"margin: 20px 0; text-align: center;\">\r\n          <span style=\"display: inline-block; font-size: 20px; font-weight: bold; color: #4caf50; background: #f1f1f1; padding: 10px 20px; border-radius: 4px; border: 1px solid #dddddd;\">\r\n            {randomCode}\r\n          </span>\r\n        </div>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          Enter this code in the password reset form on our website or app to complete the process.\r\n        </p>\r\n        <p style=\"margin: 10px 0; font-size: 16px;\">\r\n          If you didn’t request this, you can safely ignore this email. Your password will not change unless you use the code above.\r\n        </p>\r\n      </div>\r\n      <div style=\"background: #f1f1f1; text-align: center; padding: 10px; font-size: 12px; color: #555;\">\r\n        <p style=\"margin: 0;\">&copy; 2025 Cinema App. All rights reserved.</p>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>\r\n";
            try
            {
                await _emailService.SendEmail(email, userFullName, message, "Reset Cinema App Password");
            }
            catch (Exception)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }
        private string HashCode(string code)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(code);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public async Task<bool> ValidatePasswordResetCode(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new Exception(SharedResourcesKeys.EmailNotFound);

            var hashedSubmittedCode = HashCode(code);

            if (user.ResetCode != hashedSubmittedCode)
                return false;

            return true;
        }

        public async Task ResetUserPassword(string ResetCode, string newPassword)
        {
            var hashedSubmittedCode = HashCode(ResetCode);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.ResetCode == hashedSubmittedCode) ??
                throw new Exception(SharedResourcesKeys.EmailNotFound);

            var transaction = _appDbContext.Database.BeginTransaction();
            try
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, newPassword);
                user.ResetCode = null;
                await _userManager.UpdateAsync(user);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
