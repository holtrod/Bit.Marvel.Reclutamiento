using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;

namespace Bit.Marvel.Reclutamiento.Negocio.Servicios
{
    public interface IRepositorioComicsSucursal
    {
        void AgregarComicsSucursal(ComicSucursal comicSucursal);

        ComicSucursal ObtenerComicsSucursal(Guid idSucursal);
    }
}