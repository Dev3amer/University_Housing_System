using Microsoft.AspNetCore.Identity;

namespace MovieReservationSystem.Infrastructure.Seeding
{
    public static class RolesSeeder
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var adminRole = new IdentityRole("Admin");
            var employeeRole = new IdentityRole("Employee");
            var userRole = new IdentityRole("User");

            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);
                await roleManager.CreateAsync(employeeRole);
            }
        }
    }
}
