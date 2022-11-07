using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;
using Bit.Marvel.Reclutamiento.Negocio.Auxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Datos.Repositorio
{
    public class RepositorioSucursal : IRepositorioSucursal
    {
        private readonly ConnectionString _connectionString;
        private static readonly List<Sucursal> _TablaSucursal = new List<Sucursal>();
        private static RepositorioSucursal _instancia = null;
        public RepositorioSucursal()
        {
            _connectionString = new ConnectionString("") ;
        }

        public void EliminarPorId(Guid id)
        {
            var sucursal = _TablaSucursal.First(suc => suc.Id == id);
            _TablaSucursal.Remove(sucursal);
        }

        public List<Sucursal> GetSucursalAll()
        {
            return _TablaSucursal;
        }

        public Sucursal GetSucursalPorId(Guid id)
        {
            return _TablaSucursal.First(suc => suc.Id == id);
        }

        public void Guardar(Sucursal sucursal)
        {
            _TablaSucursal.Add(sucursal);
        }

        public void Actualizar(Sucursal sucursal)
        {
            var sucursalanterior = _TablaSucursal.First(suc => suc.Id == sucursal.Id);
            _TablaSucursal.Remove(sucursalanterior);
            _TablaSucursal.Add(sucursal);
        }

        public static RepositorioSucursal Instancia
        {
            get
            {
                if (null == _instancia)
                    _instancia = new RepositorioSucursal();
                return _instancia;
            }
        }
    }
}
