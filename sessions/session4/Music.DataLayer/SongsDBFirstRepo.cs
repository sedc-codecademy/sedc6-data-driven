using Music.DataLayer.Contracts;
using domain = Music.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Music.DataLayer
{
    public class SongsDBFirstRepo : ISongsRepository
    {
        private readonly MusicManagerEntities _db;

        public SongsDBFirstRepo()
        {
            _db = new MusicManagerEntities();
        }

        public virtual IEnumerable<domain.Song> GetAll(uint skip = 0, uint take = 100)
        {
            int intSkip = skip > int.MaxValue ? int.MaxValue : (int)skip;
            int intTake = take > int.MaxValue ? int.MaxValue : (int)take;
            List<Song> songs = _db.Songs.OrderBy(s=>s.Id).Skip(intSkip).Take(intTake).ToList();
            IEnumerable<domain.Song> results = songs.Select(dbSong => new domain.Song
            {
                AlbumId = dbSong.AlbumId,
                Id = dbSong.Id,
                Duration = dbSong.Duration,
                Name = dbSong.Name
            });
            return results;
        }
        public virtual domain.Song Create(domain.Song song)
        {
            throw new NotImplementedException();
        }
        public virtual bool Delete(domain.Song song)
        {
            throw new NotImplementedException();
        }        
        public virtual domain.Song GetById(int id)
        {
            throw new NotImplementedException();
        }
        public virtual domain.Song Update(domain.Song song)
        {
            throw new NotImplementedException();
        }
    }
}
