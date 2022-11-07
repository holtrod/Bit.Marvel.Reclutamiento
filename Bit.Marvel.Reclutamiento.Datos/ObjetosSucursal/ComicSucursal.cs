using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal
{
    public class ComicSucursal
    {
        private ComicSucursal(Guid idSucursal, List<int> comics)
        {
            IdSucursal = idSucursal;
            Comics = comics;
        }

        public Guid IdSucursal { get; private set; }
        public List<int> Comics { get; private set; }

        public static ComicSucursal Create(Guid idSucursal, List<int> comics)
        {
            return new ComicSucursal(idSucursal, comics);
        }

        public void AgregarComics(List<int> comics)
        {
            this.Comics = comics;
        }
        public void AgregarComic(int comics)
        {
            this.Comics = this.Comics == null ? this.Comics = new List<int>() : this.Comics;
            this.Comics.Add(comics) ;
        }
    }
}
