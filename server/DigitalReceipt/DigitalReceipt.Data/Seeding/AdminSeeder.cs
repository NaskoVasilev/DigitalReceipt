using System;
using System.Linq;
using System.Threading.Tasks;
using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static DigitalReceipt.Common.GlobalConstants;

namespace DigitalReceipt.Data.Seeding
{
    public class AdminSeeder : ISeeder
    {
        public const string Username = "root";
        public const string Password = "123456";

        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            User userFromDb = await userManager.FindByNameAsync(Username);

            if (userFromDb != null)
            {
                return;
            }

            var user = new User
            {
                UserName = Username,
                Email = "root@gmail.com",
                EmailConfirmed = true
            };

            IdentityResult result = await userManager.CreateAsync(user, Password);
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
            }

            await userManager.AddToRoleAsync(user, Roles.Administrator);
        }
    }
}
