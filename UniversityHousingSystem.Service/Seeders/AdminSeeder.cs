using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using UniversityHousingSystem.Data.Entities.Identity;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.Seeders
{
    public static class AdminSeeder
    {
        public static async Task SeedAdminAsync(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IEmailService emailService)
        {
            var adminEmail = configuration["AdminEmail"];

            if (string.IsNullOrWhiteSpace(adminEmail))
                throw new Exception("Admin email is not configured.");

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                string generatedPassword = GenerateRandomPassword();

                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, generatedPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create admin user: " +
                        string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                // Send email with password
                await emailService.SendEmail(adminEmail, "Housing App Manager", $"Your admin account has been created. Your password is: <strong>{generatedPassword}</strong>",
                    "Your Admin Account");
            }

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
                await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        private static string GenerateRandomPassword()
        {
            // You can customize the complexity here
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#$*";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 12)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
