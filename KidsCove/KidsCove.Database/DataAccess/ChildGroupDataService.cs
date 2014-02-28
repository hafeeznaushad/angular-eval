using KidsCove.Core.Contracts.DataAccess;
using NHibernate;

namespace KidsCove.Database.DataAccess
{
    public class ChildGroupDataService: NHibernateRepository, IChildGroupRepository
    {
        public ChildGroupDataService(ISessionFactory s)
            : base(s)
        {
        }
    }
}
