using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Negocio.Servicios
{
    public class RepositorioComicsSucursal : IRepositorioComicsSucursal
    {
        private static readonly List<ComicSucursal> _TablaComicsSucursal = new List<ComicSucursal>();
        private static RepositorioComicsSucursal _instancia = null;
        public void AgregarComicsSucursal(ComicSucursal comicSucursal)
        {
            var sucursal = _TablaComicsSucursal.Where(Suc => Suc.IdSucursal == comicSucursal.IdSucursal).FirstOrDefault();

            sucursal.Comics.AddRange(comicSucursal.Comics);
            sucursal.AgregarComics( sucursal.Comics.Distinct().ToList());
        }

        public ComicSucursal ObtenerComicsSucursal(Guid idSucursal)
        {
            return _TablaComicsSucursal.Where(Suc => Suc.IdSucursal == idSucursal).FirstOrDefault();
        }
        public static RepositorioComicsSucursal Instancia
        {
            get
            {
                if (null == _instancia)
                    _instancia = new RepositorioComicsSucursal();
                return _instancia;
            }
        }
    }
}
