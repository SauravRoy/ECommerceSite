using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

namespace learningMVC
{


    public interface ILogger
    {
        void Log();
    }
    public class Logger : ILogger
    {
        public void Log()
        {
            throw new NotImplementedException();
        }
    }


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

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      container.RegisterType<ILogger, Logger>();   
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}