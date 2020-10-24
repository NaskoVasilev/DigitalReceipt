using CaseManager.Controllers;
using DigitalReceipt.Models.Receipts;
using DigitalReceipt.Services;
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

        public async Task<IActionResult> Create(ReceiptInputModel model)
        {
            var receiptProducst
            return Ok();
        }
    }
}
