using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using System.Web.Configuration;

using DIScenarios.Interfaces;
using DIScenarios.ApiControllers;

namespace DIScenarios
{
	public class WebApiDependencyResolver : IDependencyResolver
	{
		private IDataManager _manager;

		public WebApiDependencyResolver(IDataManager manager)
		{
			_manager = manager;
		}

		public Object GetService(Type serviceType)
		{
			return serviceType == typeof(ValuesController) ? new ValuesController(_manager) : null;
		}

		public IEnumerable<Object> GetServices(Type serviceType)
		{
			return new List<Object>();
		}

		public IDependencyScope BeginScope()
		{
			return this;
		}

		public void Dispose()
		{

		}
	}
}