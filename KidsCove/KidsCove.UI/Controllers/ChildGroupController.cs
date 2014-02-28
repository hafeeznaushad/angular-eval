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
    public class ChildGroupController : Controller
    {
        IChildGroupRepository cgDataService;
        IDBContext ctx;
        public ChildGroupController(IDBContext ctx, IChildGroupRepository cgDataService)
        {
            this.ctx = ctx;
            this.cgDataService = cgDataService;
        }

        public JsonResult Index()
        {
            List<ChildGroup> groups = new List<ChildGroup>();
            using (ctx.Start())
            {
                groups = cgDataService.Search<ChildGroup>(x => x.Key >= 1).ToList();
            }
            return Json(groups, JsonRequestBehavior.AllowGet);
        }
    }
}
