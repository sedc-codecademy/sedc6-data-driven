using MM.BusinessLayer.Contracts;
using MM.BusinessLayer.Providers;
using System.Web.Http;

namespace MM.WebApi.Controllers
{
    [RoutePrefix("albums")]
    public class AlbumsController: ApiController
    {
        private readonly IAlbumsProvider _albumsProvider;

        public AlbumsController()
        {
            _albumsProvider = new AlbumsProvider();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll(int skip = 0,  int take =100)
        {
            return Ok(_albumsProvider.GetAll(skip, take));
        }
    }
}