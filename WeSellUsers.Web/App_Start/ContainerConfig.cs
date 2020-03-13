using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WeSellUsers.Data.Services;

namespace WeSellUsers.Web
{
  public class ContainerConfig
  {
    internal static void RegisterContainer(HttpConfiguration httpConfiguratoin)
    {
      // what services are injected into container using AutoFac
      var builder = new ContainerBuilder();

      // informs autofac about all controllers 
      builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
      builder.RegisterControllers(typeof(MvcApplication).Assembly);
      builder.RegisterType<UserRepository>()
        .As<IUserRepository>()
        .InstancePerRequest();
      builder.RegisterType<WeSellUsersDbContext>().InstancePerRequest();
       
      var container = builder.Build();
      // resolve dependencies for container throughout application
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      httpConfiguratoin.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}