using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc_Ninject.Helper;
using Mvc_Ninject.Helper.Interfaces;
using Mvc_Ninject.Infrastructure;
using Ninject;

namespace Mvc_Ninject
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
            //Setup dependency injection
            SetupDependencyInjection();

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        public void SetupDependencyInjection()
        {
            // Create Ninject standard kernel
            IKernel kernel = new StandardKernel();

            // Register interfaces
            kernel.Bind<IMessageHelper>().To<MessageHelper>();

            // MVC has to know to use our(ninject) dependency
            DependencyResolver.SetResolver(new DependencyNinjectResolver(kernel));
        }
    }
}