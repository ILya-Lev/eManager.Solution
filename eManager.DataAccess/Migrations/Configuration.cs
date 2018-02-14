using eManager.Domain;

namespace eManager.DataAccess.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<eManager.DataAccess.DepartmentDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(eManager.DataAccess.DepartmentDb context)
		{
			context.Departments.AddOrUpdate(dep => dep.Name, new[]
			{
				new Department{Name = "Engineering"},
				new Department{Name = "Sales"},
				new Department{Name = "Shipping"},
				new Department{Name = "Human Resources"},
			});
		}
	}
}
