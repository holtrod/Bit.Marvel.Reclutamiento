namespace Bit.Marvel.Reclutamiento.Presentacion.Models
{
    public class DetalleComic: CommicFromList
    {
        public int PageCount { get; set; }
        public IEnumerable<Fechas> Dates { get; set; }
    }

    public class Fechas
    {
        public string Type { get; set; }
        public string Date { get; set; }
    }
}
