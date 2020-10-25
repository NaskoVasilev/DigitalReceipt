using DigitalReceipt.Common.Settings;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static DigitalReceipt.Common.GlobalConstants;

namespace DigitalReceipt.Server.Infrastructure.Extensions
{
    public static class UserManagerExtensions
    {
        public static async Task<LoggedUserModel> GenerateTokenAsync(
            this UserManager<User> userManager,
            User user,
            bool remember,
            AppSettings settings)
        {
            IEnumerable<string> roles = await userManager.GetRolesAsync(user);
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(settings.Key);

            var subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            });

            foreach (string role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            int expirationTimeInDays = remember ?
                AuthenticationConstants.TokenLongExpirationTimeInDays :
                AuthenticationConstants.TokenShortExpirationTimeInDays;

            var tokenDiscriptor = new SecurityTokenDescriptor
            {
                Issuer = settings.ApplicationName,
                Audience = settings.ApplicationName,
                Subject = subject,
                Expires = DateTime.UtcNow.AddDays(expirationTimeInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDiscriptor);
            string securityToken = tokenHandler.WriteToken(token);

            return new LoggedUserModel
            {
                Token = securityToken,
                Email = user.Email,
                UserId = user.Id,
                Roles = roles.ToList()
            };
        }

        public static async Task<SignInResult> AuthenticateAsync(this UserManager<User> userManager, User user, string password)
        {
            if (user == null)
            {
                return SignInResult.Failed;
            }
            if (await userManager.IsLockedOutAsync(user))
            {
                return SignInResult.LockedOut;
            }
            if (!await userManager.CheckPasswordAsync(user, password))
            {
                await userManager.AccessFailedAsync(user);
                return SignInResult.Failed;
            }

            await userManager.ResetAccessFailedCountAsync(user);
            return SignInResult.Success;
        }
    }
}
