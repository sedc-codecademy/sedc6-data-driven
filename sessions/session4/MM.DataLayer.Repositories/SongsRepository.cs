using MM.Common.Models;
using MM.DataLayer.Contracts;
using dbModels = MM.DataLayer.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.DataLayer.Repositories
{
    public class SongsRepository : ISongsRepository, IRepository<Song>
    {
        private readonly dbModels.MMContext context;

        public IEnumerable<Song> GetAll(int skip = 0, int take = 100)
        {
            var result = context.Songs.Skip(skip).Take(take).ToList();
            var songs = new List<Song>();
            foreach (var song in result)
            {
                songs.Add(new Song
                {
                    AlbumId = song.AlbumId,
                    Duration = song.Duration,
                    Id = song.Id,
                    Name = song.Name
                });
            }
            return songs;
        }

        public Song GetById(int id)
        {
            throw new NotImplementedException();
        }


        public Song Create(Song album)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Song album)
        {
            throw new NotImplementedException();
        }


        public Song Update(Song album)
        {
            throw new NotImplementedException();
        }
    }
}
