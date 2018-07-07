using MM.BusinessLayer.Contracts;
using MM.BusinessLayer.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MM.WebApi.Controllers
{
    [RoutePrefix("songs")]
    public class SongsController: ApiController
    {
        private readonly ISongsProvider provider;

        public SongsController()
        {
            provider = new SongsProvider();
        }

        [Route("~/songs-with-album")]
        public IHttpActionResult GetSongsWithAlbum(int skip = 0, int take = 100)
        {
            var results = provider.GetSongsWithAlbums(skip, take);
            return Ok(results);
        }
    }
}