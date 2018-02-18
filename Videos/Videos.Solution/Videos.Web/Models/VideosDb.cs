using System.Data.Entity;

namespace Videos.Web.Models
{
	public class VideosDb : DbContext
	{
		public DbSet<Video> Videos { get; set; }
	}
}