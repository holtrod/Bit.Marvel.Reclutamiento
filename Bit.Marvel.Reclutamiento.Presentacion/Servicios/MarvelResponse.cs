namespace Bit.Marvel.Reclutamiento.Presentacion.Servicios
{
    public class MarvelResponse<T>
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public  T Data { get; set; }
    }
}
