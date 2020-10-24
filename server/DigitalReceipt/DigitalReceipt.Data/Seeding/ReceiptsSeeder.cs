using DigitalReceipt.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalReceipt.Data.Seeding
{
    public class ReceiptsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var random = new Random();
            var companies = new List<Company>();
            for (int i = 0; i < 3; i++)
            {
                companies.Add(new Company
                {
                    Name = $"Firm {i + 1}"
                });
            }

            string userId = dbContext.Users.FirstOrDefault(u => u.UserName.StartsWith("nasko"))?.Id;

            for (int i = 1; i <= 20; i++)
            {
                var receipt = new Receipt
                {
                    Date = new DateTime(2020, 10, 24 - i),
                    CashierName = $"Cashier{i}",
                    Number = random.Next(1000, 99999).ToString(),
                    FiscalNumber = $"BMLF{random.Next(100, 9999) * i}",
                    UIC = $"{random.Next(10000, 999999) * i}",
                    Company = companies[random.Next(companies.Count)],
                    CompanyAddress = $"Main Address {(i % 3) + 1}",
                    StoreName = $"Store {(i % 5) + 1}",
                    StoreAddress = $"Address {(i % 5) + 1}",
                    TaxNumber = $"BG{random.Next(10000, 999999) * i}",
                    ClientNumber = $"{random.Next(1000, 9999999)}",
                    IdFiscalNumber = $"BML{random.Next(100, 9999) * i}",
                    UserId = userId,
                    Products = GenerateProducts(random.Next(0, 5))
                        .Select(product => new ReceiptProduct
                        {
                            Product = product,
                            Quantity = 1
                        })
                        .ToList(),
                };

                await dbContext.Receipts.AddAsync(receipt);
            }
        }

        private IEnumerable<Product> GenerateProducts(int count)
        {
            var random = new Random();
            var products = new List<string> { "Coca cola", "Monster", "RedBull", "Jelly Beans", "Water" };
            for (int i = 0; i < count; i++)
            {
                yield return new Product
                {
                    Barcode = $"{random.Next(1000000, 99999999)}",
                    Name = products[random.Next(products.Count)],
                    Discount = (decimal)(random.Next(0, 10) * 0.1),
                    Price = (decimal)(random.Next(10, 30) * 0.1)
                };
            }
        }
    }
}
