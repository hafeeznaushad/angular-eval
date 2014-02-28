using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using System.Configuration;
using KidsCove.Core.Domain;
using NHibernate.Criterion;
using NHibernate.Linq;
using KidsCove.Database;
using KidsCove.Database.Mappings;
using KidsCove.Database.DataAccess;
using KidsCove.Core;
using Autofac;

namespace KidsCove.Tests
{
    [TestFixture]
    public class TestFixture1
    {
        private static ISessionFactory _sessionFactory;
        private IDBContext ctx;
        [SetUp]
        public void Setup()
        {
            _sessionFactory = Fluently.Configure()
               .Database(MySQLConfiguration.Standard.ConnectionString(ConfigurationManager.ConnectionStrings["PrimaryDB"].ConnectionString).ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ChildGroupMap>())
               .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
               .BuildSessionFactory();
            ctx = new NHibernateContext(_sessionFactory);
        }

        //[Test]
        //public void Test_Create_ActivityType()
        //{
        //    ChildActivityType cg = new ChildActivityType()
        //    {
        //        Activity = ActivityType.Feed
        //    };

        //    ActivityTypeDataService ds = new ActivityTypeDataService(_sessionFactory);
        //    using (ctx = ctx.Start())
        //    {
        //        ctx.BeginTransaction();
        //        ds.Add(cg);
        //        ctx.Commit();
        //        Console.WriteLine(cg.Key);
        //        Assert.That(cg.Key > 0);
        //    }
        //}

        [Test]
        public void Test_Create_Child_ActivityDetail()
        {
            ChildActivityDetail cg = new ChildActivityDetail()
            {
                EventDate = DateTime.Today,
                StartTime = DateTime.Now,
                Child = new ChildDetail() 
                {
                    Key = 1
                },
                Activity = new ChildActivityType()
                {
                    Key = 3
                }
            };

            NHibernateRepository ds = new NHibernateRepository(_sessionFactory);
            using (ctx = ctx.Start())
            {
                ctx.BeginTransaction();
                ds.Add(cg);
                ctx.Commit();
                Console.WriteLine(cg.Key);
                Assert.That(cg.Key > 0);
            }
        }

        //[Test]
        //public void TestTrue()
        //{


        //    ChildGroup cg = new ChildGroup()
        //    {
        //        GroupName = "Test5"
        //    };

        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        NHibernateRepository<int, ChildGroup> repo = new NHibernateRepository<int, ChildGroup>(session);
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            repo.Add(cg);
        //            //object id = session.Save(cg);
        //            Console.WriteLine(cg.Key);
        //            transaction.Commit();
        //            Assert.That(cg.Key > 0);

        //        }
        //    }
        //}

        //[Test]
        //public void TestGet()
        //{
            

            
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        NHibernateRepository<int, ChildGroup> repo = new NHibernateRepository<int, ChildGroup>(session);
        //        ChildGroup obj = repo.Get(5);
        //        Assert.That(obj != null && obj.Key == 5 && obj.GroupName.Equals("Test5", StringComparison.OrdinalIgnoreCase));

        //    }
        //}


        //[Test]
        //public void TestDelete()
        //{
        //    using (ISession session = _sessionFactory.OpenSession())
        //    {
        //        NHibernateRepository<int, ChildGroup> repo = new NHibernateRepository<int, ChildGroup>(session);
        //        using (ITransaction transaction = session.BeginTransaction())
        //        {
        //            repo.Delete(3);
        //            transaction.Commit();
        //        }
        //        ChildGroup obj = repo.Get(3);
        //        Assert.That(obj == null);

        //    }
        //}


        //[Test]
        //public void TestQuery()
        //{
        //    NHibernateContext ctx = new NHibernateContext(_sessionFactory);
        //    using (ctx.Start()) 
        //    {
        //        ChildGroupDataService repo = new ChildGroupDataService(_sessionFactory);
        //        List<ChildGroup> obj = repo.Search<ChildGroup>(x => x.Key >= 1).ToList();
        //        Assert.That(obj.Count == 2);
        //    }
        //}


        //[Test]
        //public void InstancePerMatchingLifetimeScope()
        //{
        //    var builder = new ContainerBuilder();
        //    builder.RegisterType<TestObject>().As<ITestObject>().InstancePerMatchingLifetimeScope("scope-id");
        //    var container = builder.Build();

        //    using (var namedScope = container.BeginLifetimeScope("scope-id"))
        //    {
        //        var first = namedScope.Resolve<ITestObject>();
        //        Console.WriteLine("First ID = {0}", first.Id);
        //        using (var innerScope = namedScope.BeginLifetimeScope())
        //        {
        //            var second = innerScope.Resolve<ITestObject>();
        //            Console.WriteLine("Second ID = {0}", second.Id);
        //            Assert.AreSame(first, second);
        //        }
        //    }
        //}
    }
}
