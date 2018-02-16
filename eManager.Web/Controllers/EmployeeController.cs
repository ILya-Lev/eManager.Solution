using System.Linq;
using System.Web.Mvc;
using eManager.Domain;
using eManager.Web.Models;

namespace eManager.Web.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly IDepartmentDataSource _dataSource;

		public EmployeeController(IDepartmentDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		[HttpGet]
		public ActionResult Create(int departmentId)
		{
			var viewModel = new CreateEmployeeViewModel { DepartmentId = departmentId };
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(CreateEmployeeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var department = _dataSource.Departments.Single(d => d.Id == viewModel.DepartmentId);

				var employee = new Employee
				{
					Name = viewModel.Name,
					HireDate = viewModel.HireDate
				};

				department.Employees.Add(employee);

				_dataSource.Save();
				return RedirectToAction("Details", "Department", new { id = viewModel.DepartmentId });
			}

			return View(viewModel);
		}
	}
}