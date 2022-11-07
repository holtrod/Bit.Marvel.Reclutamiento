namespace Bit.Marvel.Reclutamiento.Presentacion.Models
{
    public class MarvelDetailResult<T>
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
        public IEnumerable<T> Results { get; set; }
    }

    public class CommicFromList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int IssueNumber { get; set; }
        public Thumbnail Thumbnail { get; set; }


    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string extension { get; set; }

        public override string ToString()
        {
            return $"{Path}.{extension}";
        }
    }
    public class Personaje
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Thumbnail Thumbnail { get; set; }
    }
}
