using System.Collections.Generic;
using MM.BusinessLayer.Contracts;
using MM.Common.Models;
using dbModels = MM.DataLayer.DbModels;
using MM.DataLayer.Repositories;
using System.Linq;

namespace MM.BusinessLayer.Providers
{
    //SongsRepository   <-   ISongsRepository            
    //      |                      |    
    //      V                      V
    //SongsProvider    <-     ISongsProvider
    public class SongsProvider : SongsRepository, ISongsProvider//, ISongsRepository, IRepository<Song>
    {
        private readonly dbModels.MMContext _context;

        public SongsProvider()
        {
            _context = new dbModels.MMContext();
        }

        public IEnumerable<SongWithAlbum> GetSongsWithAlbums(int skip, int take)
        {
            var results = _context.Songs.Include("Album.Artist")
                .ToList();
            var songs = new List<SongWithAlbum>();
            foreach (var song in results)
            {
                var artistId = song.Album.Artist.Id;
                songs.Add(new SongWithAlbum
                {
                    Id = song.Id,
                    AlbumId = song.AlbumId,
                    Duration = song.Duration,
                    Name = song.Name,
                    Album = new Album
                    {
                        Year = song.Album.Year,
                        ArtistId = song.Album.ArtistId,
                        Name = song.Album.Name,
                        Id = song.Album.Id,
                        GenreId = song.Album.GenreId
                    }
                });
            }
            return songs;
        }
    }
}
