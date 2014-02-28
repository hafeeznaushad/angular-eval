using KidsCove.Core.Contracts.DataAccess;
using NHibernate;

namespace KidsCove.Database.DataAccess
{
    public class ChildDataService: NHibernateRepository, IChildRepository
    {
        public ChildDataService(ISessionFactory s)
            : base(s)
        {
        }
    }
}
