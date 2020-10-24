using CaseManager.Services;
using DigitalReceipt.Data.Models;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DigitalReceipt.Services
{
    public interface IUserService
    {
        bool Exists(Expression<Func<User, bool>> expression);

        T GetById<T>(string userId, Expression<Func<User, T>> selectExpression);

        T GetById<T>(string userId);

        Task Update<TInputModel>(string userId, TInputModel model);
    }
}
