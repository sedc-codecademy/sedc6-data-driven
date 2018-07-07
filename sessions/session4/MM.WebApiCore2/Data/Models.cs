using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MM.WebApiCore2.Data
{

    public partial class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
         public virtual ICollection<Song> Songs { get; set; }
    }

    public partial class Artist
    {
               public int Id { get; set; }
        public string FullName { get; set; }
        public int ArtistTypeId { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ArtistType ArtistType { get; set; }
    }

    public partial class ArtistType
    {
        public int Id { get; set; }
        public string Name { get; set; }

       public virtual ICollection<Artist> Artists { get; set; }
    }

    public partial class Genre
    {
  public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
    public partial class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
