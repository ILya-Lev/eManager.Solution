using System.Linq;
using System.Web.Mvc;
using eManager.Domain;

namespace eManager.Web.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IDepartmentDataSource _dataSource;

		public DepartmentController(IDepartmentDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		[HttpGet]
		public ActionResult Details(int? id)
		{
			var targetDepartment = _dataSource.Departments.FirstOrDefault(d => d.Id == id);
			if (targetDepartment == null)
				return RedirectToAction(nameof(Create));

			return View(targetDepartment);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
	}
}