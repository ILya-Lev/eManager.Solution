using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Videos.Web.Models;

namespace Videos.Web.Controllers
{
	public class VideosController : ApiController
	{
		private readonly VideosDb _db;

		// GET: api/Videos
		public VideosController()
		{
			_db = new VideosDb();
			_db.Configuration.ProxyCreationEnabled = false;
		}

		public IEnumerable<Video> Get()
		{
			return _db.Videos;
		}

		// GET: api/Videos/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Videos
		public JsonResult<Video> Post([FromBody]Video value)
		{
			return Json(value);
		}

		// PUT: api/Videos/5
		public string Put(int id, [FromBody]string value)
		{
			return $"{value} & {id}";
		}

		// DELETE: api/Videos/5
		public void Delete(int id)
		{
		}
	}
}
