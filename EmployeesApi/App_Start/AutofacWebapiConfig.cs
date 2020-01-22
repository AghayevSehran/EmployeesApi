using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;

namespace EmployeesApi.App_Start
{
    public class IoConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(
                Assembly.GetExecutingAssembly());
            //builder.RegisterType<TestService>()
            //.AsSelf().InstancePerRequest();
            IContainer container = builder.Build();
            AutofacWebApiDependencyResolver resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver =
                resolver;

        }
    }
}