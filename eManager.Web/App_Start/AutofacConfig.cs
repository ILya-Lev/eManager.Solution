using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using eManager.DataAccess;
using eManager.Domain;

namespace eManager.Web.App_Start
{
	public static class AutofacConfig
	{
		public static IContainer Configure()
		{
			var builder = CreateBuilderInitializedWithDependencies();

			return HookUpContainerIntoPipeline(builder);
		}

		private static ContainerBuilder CreateBuilderInitializedWithDependencies()
		{
			var builder = new ContainerBuilder();

			builder.RegisterControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<DepartmentDb>().As<IDepartmentDataSource>();
			return builder;
		}
		private static IContainer HookUpContainerIntoPipeline(ContainerBuilder builder)
		{
			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			return container;
		}
	}
}