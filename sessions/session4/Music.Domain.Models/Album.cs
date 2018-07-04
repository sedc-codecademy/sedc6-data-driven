namespace Music.Domain.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
    }
}
