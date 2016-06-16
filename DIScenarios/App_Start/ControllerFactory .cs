using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DIScenarios.Controllers;
using DIScenarios.Managers;
using DIScenarios.Interfaces;

namespace DIScenarios
{
    public class ControllerFactory : DefaultControllerFactory
    {
		private IDataManager _manager;
		public ControllerFactory(IDataManager manager)
        {
            _manager = manager;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == typeof(HomeController) ? new HomeController(_manager) : null;
        }
    }
}