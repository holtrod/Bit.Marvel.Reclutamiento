using Bit.Marvel.Reclutamiento.Datos.ObjetosSucursal;
using Bit.Marvel.Reclutamiento.Datos.Repositorio;
using Bit.Marvel.Reclutamiento.Negocio.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Marvel.Reclutamiento.Negocio.Servicios
{
    public class ServiciosSucursal : IServiciosSucursal
    {
        private readonly IRepositorioSucursal _repositorioSucursal;
        public ServiciosSucursal(IRepositorioSucursal repositorioSucursal)
        {
            _repositorioSucursal = repositorioSucursal;
        }

        public void Crear(DtoSucursal sucursal)
        {
            _repositorioSucursal.Guardar(Sucursal.Create(sucursal.Id, sucursal.Nombre, sucursal.Direccion));
        }

        public void Editar(DtoSucursal sucursal)
        {
            _repositorioSucursal.Actualizar(Sucursal.Create(sucursal.Id, sucursal.Nombre, sucursal.Direccion));
        }

        public void EliminarPorId(Guid id)
        {
            _repositorioSucursal.EliminarPorId(id);
        }
        public List<DtoSucursal> GetSucursalAll()
        {
           return _repositorioSucursal.GetSucursalAll().Select(sucursal => MapDtoSucursal(sucursal)).ToList();
        }

        public DtoSucursal GetSucursalPorId(Guid id)
        {
            return MapDtoSucursal(_repositorioSucursal.GetSucursalPorId(id));
        }

        private DtoSucursal MapDtoSucursal(Sucursal sucursal)
        {
            return new DtoSucursal
            {
                Id = sucursal.Id,
                Direccion = sucursal.Direccion,
                Nombre = sucursal.Nombre
            };
        }
    }
}
