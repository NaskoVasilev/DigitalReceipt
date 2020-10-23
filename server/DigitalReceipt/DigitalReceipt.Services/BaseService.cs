using DigitalReceipt.Common.Mappings;
using DigitalReceipt.Data;
using DigitalReceipt.Data.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CaseManager.Services
{
    public abstract class BaseService<T, TKey> : IBaseService<T, TKey> where T : Entity<TKey>
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public BaseService(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }

        public virtual IList<TModel> All<TModel>() => dbSet.To<TModel>().ToList();

        public IList<TModel> All<TModel>(Func<TModel, object> orderBy, bool descending = false)
        {
            IQueryable<TModel> models = dbSet.To<TModel>();
            if(descending)
            {
                return models.OrderByDescending(orderBy).ToList();
            }

            return models.OrderBy(orderBy).ToList();
        }

        public virtual async Task<TKey> Create<TInputModel>(TInputModel model)
        {
            T entity = model.To<T>();
            await dbSet.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        public virtual async Task Delete(TKey id)
        {
            T entity = dbSet.Find(id);
            dbSet.Remove(entity);
            await context.SaveChangesAsync();
        }

        public virtual TModel GetById<TModel>(TKey id) =>
            dbSet.Where(t => t.Id.Equals(id))
            .To<TModel>()
            .FirstOrDefault();

        public virtual async Task Update<TInputModel>(TKey id, TInputModel model)
        {
            T entity = dbSet.Find(id);
            model.To<T>(entity);
            dbSet.Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual bool Exists(Expression<Func<T, bool>> expression) => dbSet.Any(expression);
    }
}
