using DigitalReceipt.Data;
using DigitalReceipt.Data.Models;
using DigitalReceipt.Models.Users;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DigitalReceipt.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Exists(Expression<Func<User, bool>> expression) => context.Users.Any(expression);

        public async Task LinkToCompany(string companyId, string cashierId)
        {
            await context.CashierCompanies.AddAsync(new CashierCompany
            {
                CashierId = cashierId,
                UserId = companyId
            });

            await context.SaveChangesAsync();
        }
    }
}
