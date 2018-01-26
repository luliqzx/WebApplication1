using DataAccess.Common;
using DataAccess.Repo;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrap();
        }

        void Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            //container.Register(() => SessionProvider.SessionFactory, Lifestyle.Singleton);
            //container.Register<ISessionFactory>(() => SessionProvider.SessionFactory, Lifestyle.Singleton);
            //container.Register<ISessionFactory>(() => SessionProvider.SessionFactory2, Lifestyle.Singleton);

            container.Register<ISessionProvider, SessionProvider>(Lifestyle.Singleton);

            //var assemblies = new[] { SessionProvider.CreateSessionFactory("mssqlserverConn"), SessionProvider.CreateSessionFactory("mssqlserverConn2") };
            //container.RegisterCollection<ISessionFactory>(assemblies);
            //container.Register(typeof(IBaseRepo<>), new[] { typeof(BaseRepo<>).Assembly });
            container.Register<IUserRepo, UserRepo>(Lifestyle.Singleton);
            //container.Register<ICurrencyRepo, CurrencyRepo>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            //IUserRepo repo = new UserRepo();
            //repo.GetOne();
            ////IList<User> lstUser = repo.GetAll();

            //ICurrencyRepo CurrencyRepo = new CurrencyRepo();
            //IList<Currency> lstCurrency = CurrencyRepo.GetAll();
        }
    }
}
