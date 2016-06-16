using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DIScenarios.Interfaces;

namespace DIScenarios.Controllers
{
    public class HomeController : Controller
    {
		private IDataManager _manager;
		public HomeController(IDataManager manager) 
		{
			_manager = manager;
		}

		/// <summary>
		/// Returns the Index view.
		/// </summary>
		/// <returns></returns>
        public ActionResult Index()
        {
			//using the injected manager dependency to return the object model to the view.
			return View(_manager.GetData());
        }
    }
}
