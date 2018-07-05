using MM.BusinessLayer.Contracts;
using MM.Common.Models;
using dbmodels = MM.DataLayer.DbModels;
using MM.DataLayer.Repositories;
using System.Linq;

namespace MM.BusinessLayer.Providers
{
    public class AlbumsProvider : AlbumsRepository, IAlbumsProvider
    {
        private readonly dbmodels.MMContext _db;

        public AlbumsProvider()
        {
            _db = new dbmodels.MMContext();
        }

        public Album GetAlbumBySongId(int songId)
        {
            var dbAlbum = _db.Albums.FirstOrDefault(a =>
                                a.Songs.Any(s => s.Id == songId));

            if (dbAlbum == null)
                return null;

            return new Album
            {
                Id = dbAlbum.Id,
                ArtistId = dbAlbum.ArtistId,
                GenreId = dbAlbum.GenreId,
                Name = dbAlbum.Name,
                Year = dbAlbum.Year
            };
        }
    }
}
