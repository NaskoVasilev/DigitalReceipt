using DigitalReceipt.Server.Infrastructure.Extensions;
using DigitalReceipt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;

namespace DigitalReceipt.Server.Controllers
{
    [Authorize]
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }

        [HttpGet(nameof(SpendingByProductName))]
        public IActionResult SpendingByProductName() => 
            Ok(statisticsService.GetSpendingByProductName(User.GetUserId()));

        [HttpGet(nameof(SpendingByProductCategory))]
        public IActionResult SpendingByProductCategory() =>
            Ok(statisticsService.GetSpendingByProductCaegory(User.GetUserId()));
    }
}
