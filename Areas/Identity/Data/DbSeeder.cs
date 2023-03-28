using Microsoft.AspNetCore.Identity;
using PatientCard.Constants;

namespace PatientCard.Areas.Identity.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                //Seed Roles
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

                // creating admin
                var user = new ApplicationUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    FirstName = "Admin",
                    LastName = "Adminov",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                var userInDb = await userManager.FindByEmailAsync(user.Email);
                if (userInDb == null)
                {
                    await userManager.CreateAsync(user, "Admin@123");
                    await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(user, Roles.User.ToString());
                }
            }
        }
    }
}
