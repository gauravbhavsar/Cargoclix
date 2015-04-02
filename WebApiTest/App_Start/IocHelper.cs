using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using WebApiTest.Models;
using WebApiTest.Repository;
using System.Web.Mvc;
using System.Web.Http;
using WebApiTest.Services;

namespace assetry {
    public class iochelper {

        public static IContainer CreateContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<DataContextModule>();
            builder.RegisterModule<DataAccessLayerModule>();
            builder.RegisterModule<ServicesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            return container;
        }
    }
}