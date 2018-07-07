using Microsoft.EntityFrameworkCore;
namespace MM.WebApiCore2.Data
{
    public class MMContext:DbContext
    {
        public MMContext(DbContextOptions options):base(options)
        {
        }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistType> ArtistTypes { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
    }
}
