namespace Music.Domain.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int AlbumId { get; set; }
    }
}
