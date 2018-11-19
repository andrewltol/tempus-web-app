using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using SimpleInjector.Integration.WebApi;
using TempusWebApp.Services;

namespace TempusWebApp
{
  public static class IocConfig
  {
    public static void SetupSimpleInjector()
    {
      // Create the container as usual.
      var container = new Container();
      container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

      // Register your types, for instance using the scoped lifestyle:
      container.Register<IEmployeeService, SqlEmployeeService>(Lifestyle.Scoped);

      // This is an extension method from the integration package.
      container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

      container.Verify();

      GlobalConfiguration.Configuration.DependencyResolver =
          new SimpleInjectorWebApiDependencyResolver(container);
    }
  }
}