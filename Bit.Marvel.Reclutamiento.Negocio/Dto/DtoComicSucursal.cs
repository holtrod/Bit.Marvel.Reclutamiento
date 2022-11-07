namespace Bit.Marvel.Reclutamiento.Negocio.Dto
{
    public class DtoComicSucursal
    {
        public int Id { get; set; }
        public Guid IdSucursal { get; set; }
        public IEnumerable<int> IdComics { get; set; }
    }
}
