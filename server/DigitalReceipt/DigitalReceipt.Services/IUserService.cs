using DigitalReceipt.Data.Models;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DigitalReceipt.Services
{
    public interface IUserService
    {
        bool Exists(Expression<Func<User, bool>> expression);

        Task LinkToCompany(string companyId, string cashierId);
    }
}
