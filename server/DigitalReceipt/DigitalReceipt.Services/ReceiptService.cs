using CaseManager.Services;
using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Products;
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

        public async Task<int> Create(ReceiptInputModel model)
        {
            var receiptProducts = new List<ReceiptProduct>();
            foreach (var product in model.Products)
            {
                int productId = context.Products
                    .Where(p => p.Barcode == product.Barcode)
                    .Select(p => p.Id)
                    .FirstOrDefault();

                var receiptProduct = new ReceiptProduct() 
                {
                    Quantity = product.Quantity
                };

                if(productId == default)
                {
                    receiptProduct.ProductId = productId;
                }
                else
                {
                    var entityEntry = await context.Products.AddAsync(product.To<Product>());
                    receiptProduct.ProductId = entityEntry.Entity.Id;
                }
            }

            var receipt = model.To<Receipt>();
            int companyId = context.Companies
                .Where(c => c.Name == model.CompanyName)
                .Select(c => c.Id)
                .FirstOrDefault();

            if(companyId != default)
            {
                receipt.CompanyId = companyId;
            }
            else
            {
                receipt.Company = new Company
                {
                    Name = model.CompanyName
                };
            }

            receipt.Products = receiptProducts;
            await context.Receipts.AddAsync(receipt);
            await context.SaveChangesAsync();
            return receipt.Id;
        }

        public IList<ReceiptByCompanyViewModel> GetUserReceipts(string userId)
        {
            return
                context.Receipts
                .Where(r => r.UserId == userId)
                .To<ReceiptViewModel>()
                .AsEnumerable()
                .GroupBy(r => r.CompanyName)
                .Select(r => new ReceiptByCompanyViewModel
                {
                    CompanyName = r.Key,
                    Receipts = r.ToList()
                })
                .OrderBy(r => r.CompanyName)
                .ToList();
        }
    }
}
