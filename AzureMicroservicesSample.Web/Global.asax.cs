using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using AzureMicroservicesSample.Web.Controllers;
using AzureMicroservicesSample.Web.Services;

namespace AzureMicroservicesSample.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            ConfigureDependencyInjectionContainer();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private static void ConfigureDependencyInjectionContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<OrderService>().AsSelf();
            containerBuilder.RegisterType<OrderRepository>().AsSelf();
            containerBuilder.RegisterAssemblyTypes(typeof(HomeController).Assembly)
                .Where(t => t.Name.EndsWith("Controller"));

            var container = containerBuilder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
