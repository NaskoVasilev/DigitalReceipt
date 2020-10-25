using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data;
using DigitalReceipt.Models.Common;
using DigitalReceipt.Models.Products;
using System.Collections.Generic;
using System.Linq;

namespace DigitalReceipt.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext context;

        public StatisticsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<GroupingEntityViewModel<string, decimal>> GetSpendingByProductName(string userId)
        {
            return context
                .ReceiptProducts
                .Where(r => r.Receipt.UserId == userId)
                .To<ProductViewModel>()
                .AsEnumerable()
                .GroupBy(p => new { p.Name, p.Barcode })
                .Select(g => new GroupingEntityViewModel<string, decimal>
                {
                    Key = g.Key.Name,
                    Value = g.Sum(p => CalculateProductPrice(p.Price, p.Discount, p.Quantity))
                })
                .ToList();
        }

        public IList<GroupingEntityViewModel<string, decimal>> GetSpendingByProductCaegory(string userId)
        {
            return context
                .ReceiptProducts
                .Where(r => r.Receipt.UserId == userId)
                .Where(r => r.Product.Category != null)
                .To<ProductViewModel>()
                .AsEnumerable()
                .GroupBy(p => p.Category)
                .Select(g => new GroupingEntityViewModel<string, decimal>
                {
                    Key = g.Key.ToString(),
                    Value = g.Sum(p => CalculateProductPrice(p.Price, p.Discount, p.Quantity))
                })
                .ToList();
        }

        private decimal CalculateProductPrice(decimal price, decimal discount, int quantity) =>
            (price - discount) * quantity;
    }
}
