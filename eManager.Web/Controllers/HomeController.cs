using System.Web.Mvc;
using eManager.Domain;

namespace eManager.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IDepartmentDataSource _dataSource;

		public HomeController(IDepartmentDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public ActionResult Index()
		{
			return View(_dataSource.Departments);
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}