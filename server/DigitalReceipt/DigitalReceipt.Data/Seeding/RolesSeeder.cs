using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using static DigitalReceipt.Common.GlobalConstants;

namespace DigitalReceipt.Data.Seeding
{
    public class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, dbContext, Roles.Cashier);
            await SeedRoleAsync(roleManager, dbContext, Roles.Company);
            await SeedRoleAsync(roleManager, dbContext, Roles.Administrator);
        }

        private async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext, string roleName)
        {
            IdentityRole role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var newRole = new IdentityRole { Name = roleName };

                IdentityResult result = await roleManager.CreateAsync(newRole);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
