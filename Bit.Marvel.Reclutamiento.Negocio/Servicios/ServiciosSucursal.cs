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
        private readonly IRepositorioComicsSucursal _repositorioComicsSucursal;
        public ServiciosSucursal(IRepositorioSucursal repositorioSucursal, IRepositorioComicsSucursal repositorioComicsSucursal)
        {
            _repositorioSucursal = repositorioSucursal;
            _repositorioComicsSucursal = repositorioComicsSucursal;
        }

        public void AgregarComicSucursal(DtoComicSucursal Comics)
        {
            var comicSucursal = ComicSucursal.Create(Comics.IdSucursal, Comics.IdComics);
            _repositorioComicsSucursal.AgregarComicsSucursal(comicSucursal);
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

        public DtoComicSucursal ObtenerComicsSucursal(Guid id)
        {
            var comicSucursal = _repositorioComicsSucursal.ObtenerComicsSucursal(id);
            if (comicSucursal != null)
                return new DtoComicSucursal { IdComics = comicSucursal.Comics, IdSucursal = comicSucursal.IdSucursal };
            else
                return null;
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
