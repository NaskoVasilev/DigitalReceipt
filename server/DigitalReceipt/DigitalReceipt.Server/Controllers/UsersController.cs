using CaseManager.Controllers;
using DigitalReceipt.Common;
using DigitalReceipt.Common.Settings;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Users;
using DigitalReceipt.Server.Infrastructure.Extensions;
using DigitalReceipt.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DigitalReceipt.Common.Mappings;
using Microsoft.AspNetCore.Authorization;
using static DigitalReceipt.Common.GlobalConstants;

namespace DigitalReceipt.Server.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IUserService userService;

        public UsersController(
            UserManager<User> userManager,
            AppSettings appSettings,
            IUserService userService)
        {
            this.userManager = userManager;
            this.appSettings = appSettings;
            this.userService = userService;
        }

        [HttpPost(nameof(Login))]
        public async Task<ActionResult> Login(LoginInputModel model)
        {
            User user = await userManager.FindByNameAsync(model.Email);
            Microsoft.AspNetCore.Identity.SignInResult authenticationResult = await userManager.AuthenticateAsync(user, model.Password);
            if (authenticationResult.IsLockedOut)
            {
                return BadRequest(new string[] { ErrorMessages.LockedOutAccount });
            }
            if (!authenticationResult.Succeeded)
            {
                return BadRequest(new string[] { ErrorMessages.LoginErrorMessage });
            }

            LoggedUserModel loggedUser = await userManager.GenerateTokenAsync(user, model.Remember, appSettings);

            return Ok(loggedUser);
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(RegisterInputModel model)
        {
            if (userService.Exists(x => x.Email == model.Email))
            {
                return BadRequest("User with the same email already exists.");
            }

            User user = model.To<User>();
            user.UserName = model.Email;
            IdentityResult result = await userManager.CreateAsync(user, model.Password);

            return result.ToActionResult();
        }
    }
}
