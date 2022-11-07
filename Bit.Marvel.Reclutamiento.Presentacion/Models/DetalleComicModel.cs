using Bit.Marvel.Reclutamiento.Negocio.Dto;

namespace Bit.Marvel.Reclutamiento.Presentacion.Models
{
    public class DetalleComicModel
    {
        public List<Personaje> Personajes { get; set; }
        public DetalleComic Detalle { get; set; }
        public List<DtoSucursal> Sucursales { get; set; }
    }
}
