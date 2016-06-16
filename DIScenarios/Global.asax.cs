using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Configuration;
using System.Reflection;

using DIScenarios.Interfaces;
using DIScenarios.Managers;

namespace DIScenarios
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register(GlobalConfiguration.Configuration);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);

			#region Figure out the type of dependency to use from the application configuration file

			String type = WebConfigurationManager.AppSettings["DataManagerClass"];
			IDataManager dataManager = Activator.CreateInstance(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name, type).Unwrap() as IDataManager;

			#endregion Figure out the type of dependency to use from the application configuration file

			#region Controller Dependency Injection

			ControllerBuilder.Current.SetControllerFactory(new ControllerFactory(dataManager));

			#endregion Controller Dependency Injection

			#region Web Api Dependency Injection

			GlobalConfiguration.Configuration.DependencyResolver = new WebApiDependencyResolver(dataManager);

			#endregion Web Api Dependency Injection
		}
	}
}