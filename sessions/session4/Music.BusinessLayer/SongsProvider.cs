using Music.DataLayer.Contracts;
using Music.DataLayer.Contracts.BL;
using domain = Music.Domain.Models;
using System;
using System.Collections.Generic;
using Music.DataLayer;
using System.Linq;

namespace Music.BusinessLayer
{
    public class SongsProvider : SongsDBFirstRepo, ISongsProvider
    {
        private readonly ISongsRepository _repo;
        //private readonly IAlbumsRepository _repo;
        private readonly MusicManagerEntities _db;

        public SongsProvider()
        {
            _repo = new SongsDBFirstRepo();
            _db = new MusicManagerEntities();
        }

        public domain.Album GetAlbumBySong(int songId)
        {
            var album = _db.Albums
                .FirstOrDefault(a => a.Songs.Any(s => s.Id == songId));

            if (album == null)
                return null;

            return new domain.Album
            {
                Id = album.Id,
                ArtistId = album.ArtistId,
                GenreId = album.GenreId,
                Name = album.Name,
                Year = album.Year
            };
        }
    }
}
