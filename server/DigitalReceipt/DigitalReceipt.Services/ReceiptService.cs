using CaseManager.Services;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Receipts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalReceipt.Services
{
    public class ReceiptService : BaseService<Receipt, int>, IReceiptService
    {
        private readonly ApplicationDbContext context;

        public ReceiptService(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public override async Task<int> Create(ReceiptInputModel model)
        {
            var receiptProducts = new List<ReceiptProduct>();
            foreach (var product in model.Products)
            {
                int? productId = context.Products
                    .Where(p => p.Barcode == product.Barcode)
                    .Select(p => p.Id)
                    .FirstOrDefault();

                var receiptProduct = new ReceiptProduct();
                if(productId.HasValue)
                {
                    receiptProduct.ProductId = productId.Value;
                }
                else
                {
                    var entityEntry = await context.Products.AddAsync(product.To<Product>());
                    receiptProduct.ProductId = entityEntry.Entity.Id;
                }
            }

            var receipt = model.To<Receipt>();
            receipt.Products = receiptProducts;
            await context.Receipts.AddAsync(receipt);
            await context.SaveChangesAsync();
            return receipt.Id;
        }
    }
}
