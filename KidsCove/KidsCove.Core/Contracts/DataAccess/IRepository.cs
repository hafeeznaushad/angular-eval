using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace KidsCove.Core.Contracts.DataAccess
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity);
        void Delete<TEntity>(TEntity entity);
        void DeleteByPrimaryKey<TKey, TEntity>(TKey key);

        IEnumerable<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> expression);
        TEntity Get<TKey, TEntity>(TKey key);
    }
}
