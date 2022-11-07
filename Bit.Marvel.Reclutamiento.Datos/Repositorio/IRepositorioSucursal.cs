using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Datos.Repositorio
{
    public interface IRepositorioSucursal
    {
        void Guardar(Sucursal sucursal);
        Sucursal GetSucursalPorId(Guid id);
        List<Sucursal> GetSucursalAll();
        void EliminarPorId(Guid id);
        void Actualizar(Sucursal sucursal);
    }
}
