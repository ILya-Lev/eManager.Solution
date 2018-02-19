using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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

		public IEnumerable<Video> GetAllVideos()
		{
			return _db.Videos;
		}

		// GET: api/Videos/5
		public Video Get(int id)
		{
			var video = _db.Videos.Find(id);
			if (video == null)
			{
				throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Video with id '{id}'"));
				//throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound, $"Video with id '{id}'"));
			}

			return video;
		}

		// POST: api/Videos
		public HttpResponseMessage Post([FromBody]Video value)
		{
			if (!ModelState.IsValid)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			_db.Videos.Add(value);
			_db.SaveChanges();

			var response = Request.CreateResponse(HttpStatusCode.Created, value);
			response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = value.Id }));
			return response;
		}

		// PUT: api/Videos/5
		public HttpResponseMessage Put(int id, [FromBody]Video value)
		{
			if (ModelState.IsValid && id == value.Id)
			{
				_db.Entry(value).State = EntityState.Modified;
				try
				{
					_db.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK, value);
				}
				catch (DbUpdateConcurrencyException exc)
				{
					return Request.CreateResponse(HttpStatusCode.NotFound, exc.Message);
				}
			}

			return Request.CreateResponse(HttpStatusCode.BadRequest);
		}

		// DELETE: api/Videos/5
		public HttpResponseMessage Delete(int id)
		{
			if (!ModelState.IsValid)
				return Request.CreateResponse(HttpStatusCode.BadRequest);

			var video = _db.Videos.Find(id);
			if (video == null)
				throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Video with id '{id}'"));

			_db.Videos.Remove(video);
			_db.SaveChanges();

			return Request.CreateResponse(HttpStatusCode.OK, $"Video with id '{id}' was removed");
		}
	}
}
