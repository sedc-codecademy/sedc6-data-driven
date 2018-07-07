using System.Web.Http;

namespace MM.WebApi.Controllers
{
    [RoutePrefix("artists")]
    public class ArtistsController : ApiController
    {

        public IHttpActionResult GetArtists(int skip = 0, int take = 100)
        {
            throw new System.NotImplementedException();
        }
    }
}