using System.Web.Http;

namespace MM.WebApi.Controllers
{
    [RoutePrefix("artists")]
    public class ArtistsController : ApiController
    {
        IArtistsProvider 

        public IHttpActionResult GetArtists(int skip = 0, int take = 100)
        {

        }
    }
}