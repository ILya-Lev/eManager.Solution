using Videos.Web.Models;

namespace Videos.Web.Migrations
{
	using System.Data.Entity.Migrations;

	internal sealed class Configuration : DbMigrationsConfiguration<Videos.Web.Models.VideosDb>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}

		protected override void Seed(Videos.Web.Models.VideosDb context)
		{
			context.Videos.AddOrUpdate(v => v.Title,
				new Video { Length = 120, Title = "Prometheus" },
				new Video { Length = 145, Title = "Star wars" });
			context.SaveChanges();
		}
	}
}
