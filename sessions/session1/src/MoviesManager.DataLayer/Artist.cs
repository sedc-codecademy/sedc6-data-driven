namespace MoviesManager
{
    public class Artist
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public override string ToString()
        {
            return $"ID:{Id}: {FullName}";
        }
    }
}
