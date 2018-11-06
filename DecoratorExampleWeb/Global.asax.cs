using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace DecoratorExampleWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new SimpleInjector.Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            container.Register<ICacheService, CacheService>(Lifestyle.Singleton);
            
            container.Register<IOrderService, OrderService>(Lifestyle.Scoped);
            
            container.RegisterDecorator(typeof(IOrderService),typeof(OrderCacheService));

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
      
            container.Verify();
          
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
