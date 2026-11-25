using EcoLink.Constants;
using EcoLink.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoLink.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            bool isDevelopment)
        {
            foreach (var role in AppRoles.All)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }

            var adminEmail = configuration["Seed:AdminEmail"]
                ?? throw new InvalidOperationException("Seed:AdminEmail is missing from configuration.");
            var adminPassword = configuration["Seed:AdminPassword"]
                ?? throw new InvalidOperationException("Seed:AdminPassword is missing from configuration.");

            await CreateUserIfMissingAsync(userManager, adminEmail, "System Admin", adminPassword, AppRoles.Admin);

            if (isDevelopment)
            {
                const string testPassword = "Test@12345";
                await CreateUserIfMissingAsync(userManager, "employee@ecolink.com", "Test Employee", testPassword, AppRoles.BranchEmployee);
                await CreateUserIfMissingAsync(userManager, "factory@ecolink.com", "Test Factory", testPassword, AppRoles.Factory);
                await CreateUserIfMissingAsync(userManager, "driver@ecolink.com", "Test Driver", testPassword, AppRoles.Driver);
            }
        }

        private static async Task CreateUserIfMissingAsync(
            UserManager<ApplicationUser> userManager,
            string email, string fullName, string password, string role)
        {
            if (await userManager.FindByEmailAsync(email) != null)
                return;

            var user = new ApplicationUser
            {
                Email = email,
                UserName = email,
                FullName = fullName,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create {email}: {errors}");
            }

            await userManager.AddToRoleAsync(user, role);
        }
    }
}