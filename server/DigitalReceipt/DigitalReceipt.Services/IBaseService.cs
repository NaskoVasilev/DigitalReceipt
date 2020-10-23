using DigitalReceipt.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CaseManager.Services
{
    public interface IBaseService<T, TKey> where T : Entity<TKey>
    {
        IList<TModel> All<TModel>();

        IList<TModel> All<TModel>(Func<TModel, object> orderBy, bool descending = false);

        Task<TKey> Create<TInputModel>(TInputModel model);

        Task Update<TInputModel>(TKey id, TInputModel model);

        Task Delete(TKey id);

        TModel GetById<TModel>(TKey id);

        bool Exists(Expression<Func<T, bool>> expression);
    }
}
