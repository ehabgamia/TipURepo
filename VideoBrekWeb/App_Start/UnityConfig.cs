using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity;
using Unity.Mvc5;
using VideoBrek.Data.Interfaces;
using VideoBrek.Services.Media;
using VideoBrekWeb.Models;
using VideoBrekWeb.Services.Category;

namespace VideoBrekWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType(typeof(IRepository<>), typeof(EfRepository<>));

            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IMediaServices, MediaServices>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
      
    }
}