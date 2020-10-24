using DigitalReceipt.Models.Receipts;
using DigitalReceipt.Server.Infrastructure.Extensions;
using DigitalReceipt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DigitalReceipt.Server.Controllers
{
    public class ReceiptsController : ApiController
    {
        private readonly IReceiptService receiptService;

        public ReceiptsController(IReceiptService receiptService)
        {
            this.receiptService = receiptService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceiptInputModel model)
        {
            var id = await receiptService.Create(model);
            return Ok(id);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get() => Ok(receiptService.GetUserReceipts(User.GetUserId()));
    }
}
