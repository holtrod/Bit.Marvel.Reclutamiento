
using Bit.Marvel.Reclutamiento.Datos.Repositorio;
using Bit.Marvel.Reclutamiento.Negocio.Auxiliares;
using Bit.Marvel.Reclutamiento.Negocio.Dto;
using Bit.Marvel.Reclutamiento.Negocio.Servicios;

namespace Bit.Marvel.Reclutamiento.Pruebas
{
    public class PruebasSucursal
    {
        private readonly IServiciosSucursal _serviciosSucursal;
        private readonly IRepositorioSucursal _repositorioSucursal;
        private readonly IRepositorioComicsSucursal _repositorioComicsSucursal;
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly ConnectionString _conect;

        public PruebasSucursal()
        {
            _conect = new ConnectionString("cadena de conexión");
            _repositorioSucursal = RepositorioSucursal.Instancia;
            _repositorioComicsSucursal = RepositorioComicsSucursal.Instancia;
            _serviciosSucursal = new ServiciosSucursal(_repositorioSucursal, _repositorioComicsSucursal);
        }

        [Fact]
        public void CrearNuevaSucursal()
        {
            DtoSucursal dtoSucursal = new DtoSucursal { 
                Id = Guid.NewGuid(),  
                Direccion = "Calle 16 de Septiembre Nte #636 Colonia Lázaro Cárdenas. C.P. 52148, 52148 Metepec, Méx.",
                Nombre = "Bit"
            };
            _serviciosSucursal.Crear(dtoSucursal);

            Assert.NotEmpty(_serviciosSucursal.GetSucursalAll());
        }

        [Fact]
        public void ObtenerSucursalByIdTest()
        {
            DtoSucursal dtoSucursal = new DtoSucursal
            {
                Id = Guid.NewGuid(),
                Direccion = "Calle 16 de Septiembre Nte #636 Colonia Lázaro Cárdenas. C.P. 52148, 52148 Metepec, Méx.",
                Nombre = "Bit"
            };
            _serviciosSucursal.Crear(dtoSucursal);

            DtoSucursal sucursal  = _serviciosSucursal.GetSucursalPorId(dtoSucursal.Id);

            Assert.True(sucursal.Nombre == "Bit");
        }

        [Fact]
        public void EditarTest()
        {
            DtoSucursal dtoSucursal = new DtoSucursal
            {
                Id = Guid.NewGuid(),
                Direccion = "Calle 16 de Septiembre Nte #636 Colonia Lázaro Cárdenas. C.P. 52148, 52148 Metepec, Méx.",
                Nombre = "Bit"
            };
            _serviciosSucursal.Crear(dtoSucursal);

            DtoSucursal sucursal = _serviciosSucursal.GetSucursalPorId(dtoSucursal.Id);
            sucursal.Nombre = "Editada";
            _serviciosSucursal.Editar(sucursal);
            DtoSucursal sucursal2 = _serviciosSucursal.GetSucursalPorId(dtoSucursal.Id);

            Assert.True(sucursal2.Nombre == "Editada");
        }
    }
}