using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;
using Bit.Marvel.Reclutamiento.Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Negocio.Servicios
{
    public interface IServiciosSucursal
    {
        void Crear(DtoSucursal sucursal);
        DtoSucursal GetSucursalPorId(Guid id);
        List<DtoSucursal> GetSucursalAll();
        void EliminarPorId(Guid id);
        void Editar(DtoSucursal sucursal);
    }
}
