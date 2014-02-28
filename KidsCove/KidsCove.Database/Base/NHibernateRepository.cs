using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using KidsCove.Core.Contracts.DataAccess;
using NHibernate;
using NHibernate.Linq;

namespace KidsCove.Database
{
    public class NHibernateRepository : IRepository
    {
        protected readonly ISessionFactory _sessionFactory;

        public NHibernateRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        protected virtual ISession GetCurrentSession()
        {
            return _sessionFactory.GetCurrentSession();
        }

        public void Add<TEntity>(TEntity entity)
        {
            
            GetCurrentSession().Save(entity);
        }


        public void Update<TEntity>(TEntity entity)
        {
            GetCurrentSession().Update(entity);
        }

        public void Delete<TEntity>(TEntity entity)
        {
            GetCurrentSession().Delete(entity);
        }

        public void DeleteByPrimaryKey<TKey, TEntity>(TKey id)
        {
            GetCurrentSession().Delete(GetCurrentSession().Load(typeof(TEntity), id));
        }

        public TEntity Get<TKey, TEntity>(TKey id)
        {
            return GetCurrentSession().Get<TEntity>(id);
        }

        public IEnumerable<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> expression)
        {
            return GetCurrentSession().Query<TEntity>().Where(expression).ToList<TEntity>();
        }

    }
}
