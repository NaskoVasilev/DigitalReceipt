using DigitalReceipt.Data.Models;
using System;
using System.Linq.Expressions;

namespace DigitalReceipt.Services
{
    public interface IUserService
    {
        bool Exists(Expression<Func<User, bool>> expression);
    }
}
