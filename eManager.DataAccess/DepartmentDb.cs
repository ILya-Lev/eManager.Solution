using System.Data.Entity;
using System.Linq;
using eManager.Domain;

namespace eManager.DataAccess
{
	public class DepartmentDb : DbContext, IDepartmentDataSource
	{
		public DepartmentDb() : base("DefaultConnection")
		{

		}

		public DbSet<Employee> Employees { get; set; }

		public DbSet<Department> Departments { get; set; }

		void IDepartmentDataSource.Save() => base.SaveChanges();

		IQueryable<Employee> IDepartmentDataSource.Employees => Employees;

		IQueryable<Department> IDepartmentDataSource.Departments => Departments;
	}
}
