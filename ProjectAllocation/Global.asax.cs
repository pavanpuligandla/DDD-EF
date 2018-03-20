using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ProjectAllocation.API.Core;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ProjectAllocation.Modules;


namespace ProjectAllocation
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
           
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            GlobalConfiguration.Configuration.MessageHandlers.Add(new AuthHandler());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           
            //Autofac Configuration
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterModule(new EFModule());

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
