using DigitalReceipt.Common.Mappings;
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

        public T GetById<T>(string userId, Expression<Func<User, T>> selectExpression) =>
            context.Users
            .Where(x => x.Id == userId)
            .Select(selectExpression)
            .FirstOrDefault();

        public T GetById<T>(string userId) =>
            context.Users
            .Where(x => x.Id == userId)
            .To<T>()
            .FirstOrDefault();

        public virtual async Task Update<TInputModel>(string userId, TInputModel model)
        {
            User entity = context.Users.Find(userId);
            model.To<User>(entity);
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
