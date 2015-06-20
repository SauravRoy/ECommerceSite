using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using CommonUtils;

namespace EcommerceServiceLayer
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
            var container = new UnityContainer();
            container.RegisterType<ILogger, EventLogger>();
            container.RegisterType<IMail, EmailService>();
            RegisterTypes(container);

            return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}