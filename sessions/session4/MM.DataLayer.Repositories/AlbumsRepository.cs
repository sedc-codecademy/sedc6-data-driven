using MM.Common.Models;
using MM.DataLayer.Contracts;
using dbmodels = MM.DataLayer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.DataLayer.Repositories
{
    public class AlbumsRepository : IAlbumRepository
    {
        private readonly dbmodels.MMContext _db;

        public AlbumsRepository()
        {
            _db = new dbmodels.MMContext();
        }

        public IEnumerable<Album> GetAll(int skip = 0, int take = 100)
        {
            skip = skip < 0 ? 0 : skip;
            take = take < 0 ? 100 : take;
            List<dbmodels.Album> results = _db.Albums.Skip(skip).Take(take).ToList();
            return results.Select(dbAlbum => new Album
            {
                Id = dbAlbum.Id,
                ArtistId = dbAlbum.ArtistId,
                GenreId = dbAlbum.GenreId,
                Name = dbAlbum.Name,
                Year = dbAlbum.Year
            });
        }

        public Album GetById(int id)
        {
            dbmodels.Album result = _db.Albums.FirstOrDefault(a => a.Id == id);
            if (result == null)
                return null;

            return new Album
            {
                Id = result.Id,
                ArtistId = result.ArtistId,
                GenreId = result.GenreId,
                Name = result.Name,
                Year = result.Year
            };
        }
        public Album Create(Album album)
        {
            throw new NotImplementedException();
        }
        public bool Delete(Album album)
        {
            throw new NotImplementedException();
        }
        public Album Update(Album album)
        {
            throw new NotImplementedException();
        }
    }
}
