using KidsCove.Core.Contracts.DataAccess;
using NHibernate;

namespace KidsCove.Database.DataAccess
{
    public class ActivityDetailDataService: NHibernateRepository, IActivityDetailRepository
    {
        public ActivityDetailDataService(ISessionFactory s)
            : base(s)
        {
        }
    }
}
