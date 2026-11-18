using EcoLink.Models;
using Microsoft.AspNetCore.Identity;

namespace EcoLink.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(
     RoleManager<IdentityRole<int>> roleManager,
     UserManager<ApplicationUser> userManager,
     IConfiguration configuration)
        {

            string[] roles = { "Admin", "BranchEmployee", "Factory", "Driver" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole<int>(role));
            }




            var adminEmail = configuration["Seed:AdminEmail"]
    ?? throw new InvalidOperationException("Seed:AdminEmail is missing from configuration.");

            var adminPassword = configuration["Seed:AdminPassword"]
                ?? throw new InvalidOperationException("Seed:AdminPassword is missing from configuration.");


            var existingAdmin = await userManager.FindByEmailAsync(adminEmail);
            if (existingAdmin != null)
                return;


            var admin = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminEmail,
                FullName = "System Admin",
                EmailConfirmed = true,
            };


            var result = await userManager.CreateAsync(admin, adminPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to create admin: {errors}");
            }

            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
