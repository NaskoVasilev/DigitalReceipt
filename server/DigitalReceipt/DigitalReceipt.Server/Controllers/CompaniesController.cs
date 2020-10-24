using CaseManager.Controllers;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Companies;
using DigitalReceipt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static DigitalReceipt.Common.GlobalConstants;
using DigitalReceipt.Common.Mappings;

namespace DigitalReceipt.Server.Controllers
{
    public class CompaniesController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly ICompanyService companyService;

        public CompaniesController(
            UserManager<User> userManager,
            ICompanyService companyService)
        {
            this.userManager = userManager;
            this.companyService = companyService;
        }

        [Authorize(Roles = Roles.Administrator)]
        [HttpPost]
        public async Task<IActionResult> Create(CompanyInputModel model)
        {
            var user = new User
            {
                UserName = model.UserName,
                Email = model.UserName,
            };

            await userManager.CreateAsync(user, model.Password);
            await userManager.AddToRoleAsync(user, Roles.Company);

            var company = model.To<CompanyServiceModel>();
            company.UserId = user.Id;
            await companyService.Create(model);
            return Ok();
        }
    }
}
