using Bit.Marvel.Reclutamiento.Negocio.Dto;
using Bit.Marvel.Reclutamiento.Presentacion.Models;

namespace Bit.Marvel.Reclutamiento.Presentacion.Servicios
{
    public interface IServiciosExternos
    {
        MarvelDetailResult<CommicFromList> ConsultarCommics();
        MarvelDetailResult<Personaje> ConsultarPersonajesComic(int id);

        MarvelDetailResult<DetalleComic> ConsultarDetalleComic(int id);
    }
}
