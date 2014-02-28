using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KidsCove.Core.Contracts.DataAccess;
using KidsCove.Core.Domain;
using KidsCove.Database;
using NHibernate;
using KidsCove.Core;

namespace KidsCove.UI.Controllers
{
    public class ActivityTypeController : Controller
    {
        IActivityTypeRepository activityRepository;
        IDBContext ctx;
        public ActivityTypeController(IDBContext ctx, IActivityTypeRepository cgDataService)
        {
            this.ctx = ctx;
            this.activityRepository = cgDataService;
        }

        public ActionResult Index()
        {
            List<ChildActivityType> kids = new List<ChildActivityType>();
            using (ctx.Start())
            {
                kids = activityRepository.Search<ChildActivityType>(x => x.Key >= 1).ToList();
            }
            return View(kids);
        }
    }
}
