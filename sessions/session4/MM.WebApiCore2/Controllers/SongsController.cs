using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using MM.WebApiCore2.Data;

namespace MM.WebApiCore2.Controllers
{
    [Route("/songs")]
    public class SongsController : Controller
    {

        private readonly MMContext _context;

        public SongsController(MMContext context)
        {
            _context = context;
        }

        [HttpGet("/songs-with-album")]
        public IActionResult GetWithAlbums()
        {
            var songs = _context.Songs
                .Include(s => s.Album)
                    .ThenInclude(a => a.Artist)
                        .ThenInclude(a => a.ArtistType)
                .ToList();
            return Ok(songs);
        }
    }
}
