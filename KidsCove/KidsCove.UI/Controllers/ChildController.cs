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
    public class ChildController : Controller
    {
        IChildRepository cgDataService;
        IDBContext ctx;
        public ChildController(IDBContext ctx, IChildRepository cgDataService)
        {
            this.ctx = ctx;
            this.cgDataService = cgDataService;
        }

        public ActionResult Index()
        {
            List<ChildDetail> kids = new List<ChildDetail>();
            using (ctx.Start())
            {
                kids = cgDataService.Search<ChildDetail>(x => x.Key >= 1).ToList();
            }
            return View(kids);
        }
    }
}
