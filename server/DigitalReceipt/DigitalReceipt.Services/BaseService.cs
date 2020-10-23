using CaseManager.Common.Mappings;
using CaseManager.Data;
using CaseManager.Data.Common;
using CaseManager.Models.Common;
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
        private readonly CaseManagerDbContext context;
        private readonly DbSet<T> dbSet;

        public BaseService(CaseManagerDbContext context)
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

        public async Task Update<TEntity>(
            ICollection<TEntity> currentEntites,
            IEnumerable<IIdentifiableEntity<int?>> inputModels)
            where TEntity : Entity<int>
        {
            Update(currentEntites, inputModels, out IEnumerable<TEntity> entitesToAdd);

            await context.Set<TEntity>().AddRangeAsync(entitesToAdd);
        }

        public void Update<TEntity>(
            ICollection<TEntity> currentEntites,
            IEnumerable<IIdentifiableEntity<int?>> inputModels,
            out IEnumerable<TEntity> entitiesToAdd)
            where TEntity : Entity<int>
        {
            if(inputModels == null)
            {
                inputModels = new List<IIdentifiableEntity<int?>>();
            }
            if(!currentEntites.Any() && !inputModels.Any())
            {
                entitiesToAdd = new List<TEntity>();
                return;
            }

            DbSet<TEntity> entites = context.Set<TEntity>();

            // Remove entites which are maraked as deleted
            IEnumerable<TEntity> entitiesToDelete = GetEneitiesToDelete(currentEntites, inputModels);
            entites.RemoveRange(entitiesToDelete);

            // Update the entites which are marked for update
            UpdateEntites(currentEntites, inputModels, entites);

            // Get the entites which are added
            entitiesToAdd = GetEntitesToAdd<TEntity>(inputModels);
        }

        public IEnumerable<TEntity> GetEntitesToAdd<TEntity>(
            IEnumerable<IIdentifiableEntity<int?>> inputModels) 
            where TEntity : Entity<int> => inputModels
                        .Where(i => i.Id == null || !i.Id.HasValue)
                        .Select(model => model.To<TEntity>());

        public void UpdateEntites<TEntity>(
            ICollection<TEntity> currentEntites, IEnumerable<IIdentifiableEntity<int?>> inputModels, 
            DbSet<TEntity> entites) 
            where TEntity : Entity<int>
        {
            foreach (IIdentifiableEntity<int?> inputModel in inputModels.Where(m => m.Id != null && m.Id.HasValue))
            {
                TEntity targertEntity = currentEntites.FirstOrDefault(c => c.Id == inputModel.Id.Value);
                if (targertEntity != null)
                {
                    inputModel.To<TEntity>(targertEntity);
                    entites.Update(targertEntity);
                }
            }
        }

        public IEnumerable<TEntity> GetEneitiesToDelete<TEntity>(
            ICollection<TEntity> currentEntites, 
            IEnumerable<IIdentifiableEntity<int?>> inputModels) 
            where TEntity : Entity<int>
        {
            var entityIds = new HashSet<int>(
                inputModels
                .Where(i => i.Id != null && i.Id.HasValue)
                .Select(i => i.Id.Value));

            IEnumerable<TEntity> entitiesToDelete = currentEntites
                .Where(c => !entityIds.Contains(c.Id));

            return entitiesToDelete;
        }

        public virtual bool Exists(Expression<Func<T, bool>> expression) => dbSet.Any(expression);
    }
}
