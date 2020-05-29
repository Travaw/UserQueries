
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using ProgCentrTestTask.Web.App_Start;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProgCentrTestTask.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectModule ninjectModule = new DIConfig();
            IKernel kernel = new StandardKernel(ninjectModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            ModelValidatorProviders.Providers.Clear();
        }
    }
}
