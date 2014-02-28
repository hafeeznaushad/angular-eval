using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;
using KidsCove.Core;
using NHibernate.Context;

namespace KidsCove.Database
{
    public class NHibernateContext : IDBContext
    {
        
        public NHibernateContext(ISessionFactory sessionFactory)
        {
            SessionFactory = sessionFactory;
        }

        #region Dependencies

        public ISessionFactory SessionFactory
        {
            get;
            private set;
        }

        #endregion

        #region IUnitOfWork Members

        public virtual void BeginTransaction()
        {
            var session = SessionFactory.GetCurrentSession();
            if (!session.Transaction.IsActive)
            {
                session.BeginTransaction();
            }
        }

        public virtual void Commit()
        {
            var session = SessionFactory.GetCurrentSession();
            if (session.Transaction.IsActive)
            {
                session.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            var session = SessionFactory.GetCurrentSession();
            if (session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
            }
        }

        public IDBContext Start()
        {
            if (!CurrentSessionContext.HasBind(SessionFactory))
            {
                var session = SessionFactory.OpenSession();
                session.FlushMode = FlushMode.Commit;
                CurrentSessionContext.Bind(session);
            }
            return this;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            
            var session = CurrentSessionContext.Unbind(SessionFactory);

            var transaction = session.Transaction;
            if (transaction.IsActive)
            {
                transaction.Dispose();
            }
            session.Dispose();
        }

        #endregion
    }
}
