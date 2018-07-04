using Music.BusinessLayer;
using Music.DataLayer.Contracts.BL;
using System.Web.Http;

namespace Music.WebApp.Controllers
{
    [RoutePrefix("songs")]
    public class SongsController : ApiController
    {
        private readonly ISongsProvider _songsProvider;

        //public SongsController(ISongsProvider songsProvider)
        //{
        //    _songsProvider = songsProvider;
        //}

        public SongsController()
        {
            _songsProvider = new SongsProvider();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAllSongs(int skip = 0, int take = 100)
        {
            int takePositive = take < 0 ? 0 : take;
            int skipPositive = skip < 0 ? 100 : skip;
            var songs = _songsProvider.GetAll((uint)skipPositive, (uint)takePositive);
            return Ok(songs);
        }
    }
}