using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using KidsCove.UI.Controllers;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using KidsCove.Database.Mappings;
using NHibernate;
using System.Reflection;
using KidsCove.Database.DataAccess;
using KidsCove.Database;
using KidsCove.Core;

namespace KidsCove.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            var builder = new ContainerBuilder();

            var sessionFactory = Fluently.Configure()
               .Database(MySQLConfiguration.Standard.ConnectionString(ConfigurationManager.ConnectionStrings["PrimaryDB"].ConnectionString).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChildGroupMap>())
               .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
               .BuildSessionFactory();

            builder.RegisterInstance(sessionFactory).As<ISessionFactory>().SingleInstance().ExternallyOwned();

            builder.RegisterType<NHibernateContext>().As<IDBContext>().SingleInstance();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ChildGroupDataService)))
                .Where(t => t.Name.EndsWith("DataService"))
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(ChildGroupController)))
                .Where(t => t.Name.EndsWith("Controller"))
                .AsSelf();


            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}