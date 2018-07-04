using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Music.WebApp.Controllers
{
    [RoutePrefix("songs")]
    public class SongsController : ApiController
    {
        public IHttpActionResult GetAllSongs()
        {
            var db = new Music.DataLayer.MusicManagerEntities();
            db.Songs
        }
    }
}