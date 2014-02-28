using KidsCove.Core.Contracts.DataAccess;
using NHibernate;

namespace KidsCove.Database.DataAccess
{
    public class ActivityTypeDataService: NHibernateRepository, IActivityTypeRepository
    {
        public ActivityTypeDataService(ISessionFactory s)
            : base(s)
        {
        }
    }
}
