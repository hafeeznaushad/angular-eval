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
    public class HomeController : Controller
    {
        IChildGroupRepository cgDataService;
        IDBContext ctx;
        public HomeController(IDBContext ctx, IChildGroupRepository cgDataService)
        {
            this.ctx = ctx;
            this.cgDataService = cgDataService;
        

        }

        public ActionResult Index()
        {
            List<ChildGroup> groups = new List<ChildGroup>();
            
            using (ctx.Start())
            {
                groups = cgDataService.Search<ChildGroup>(x => x.Key >= 1).ToList();
            }
            ViewBag.Message = "Welcome to ASP.NET MVC!" + groups.Count;
            //SessionManager
            return View();
        }

    }
}
