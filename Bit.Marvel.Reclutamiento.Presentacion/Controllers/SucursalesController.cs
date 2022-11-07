using Bit.Marvel.Reclutamiento.Negocio.Dto;
using Bit.Marvel.Reclutamiento.Negocio.Servicios;
using Bit.Marvel.Reclutamiento.Presentacion.Models;
using Bit.Marvel.Reclutamiento.Presentacion.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bit.Marvel.Reclutamiento.Presentacion.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly IServiciosSucursal _serviciosSucursal;
        private readonly IServiciosExternos _serviciosExternos;
        public SucursalesController(IServiciosSucursal serviciosSucursal, IServiciosExternos serviciosExternos)
        {
            _serviciosSucursal = serviciosSucursal;
            _serviciosExternos = serviciosExternos;
        }

        // GET: SucursalesController1
        public ActionResult Index()
        {
            var sucursales = _serviciosSucursal.GetSucursalAll().Select(suc => new ModelSucursal { Id = suc.Id, Direccion = suc.Direccion, Nombre = suc.Nombre });
            return View(sucursales);
        }

        // GET: SucursalesController1/Details/5
        public ActionResult Details(Guid id)
        {
            var comicsSucursal = _serviciosSucursal.ObtenerComicsSucursal(id);
            var comicsEnSucursal = new List<DetalleComic>();
            if(comicsSucursal != null)
            foreach (var comic in comicsSucursal.IdComics)
            {
                comicsEnSucursal.Add(_serviciosExternos.ConsultarDetalleComic(comic).Results.First());
            }
            return View(comicsEnSucursal.Select(comic => new CommicFromList { Id = comic.Id, IssueNumber = comic.IssueNumber, Thumbnail = comic.Thumbnail, Title = comic.Title }).ToList());
            
        }

        // GET: SucursalesController1/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ConsultarPersonajesporCommic(int id)
        {
            return View(_serviciosExternos.ConsultarPersonajesComic(id));
        }

        public ActionResult ConsultarDetalleCommic(int id)
        {
            return View(_serviciosExternos.ConsultarDetalleComic(id));
        }

        // POST: SucursalesController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ModelSucursal p)
        {
            try
            {
                var sucursal = new DtoSucursal { Id = Guid.NewGuid(), Direccion = p.Direccion, Nombre = p.Nombre };
                _serviciosSucursal.Crear(sucursal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SucursalesController1/Edit/5
        public ActionResult Edit(Guid id)
        {
            var suc = _serviciosSucursal.GetSucursalPorId(id);
            var commicsdisponibles = _serviciosExternos.ConsultarCommics();


            return View(new ModelEditSucursal { Id = suc.Id, Direccion = suc.Direccion, Nombre = suc.Nombre, ComicsDisponibles = _serviciosExternos.ConsultarCommics() });
        }

        // POST: SucursalesController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, [FromForm] ModelSucursal p)
        {
            try
            {
                var sucursal = new DtoSucursal { Id = id, Direccion = p.Direccion, Nombre = p.Nombre };
                _serviciosSucursal.Editar(sucursal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SucursalesController1/Delete/5
        public ActionResult Delete(Guid id)
        {
            _serviciosSucursal.EliminarPorId(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: SucursalesController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AgregarComicsSucursal([FromBody] DtoComicSucursal dtoComicSucursal)
        {
            try
            {
                _serviciosSucursal.AgregarComicSucursal(dtoComicSucursal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public ActionResult DetalleComic(int id)
        {
            return View(new DetalleComicModel
            {
                Detalle = _serviciosExternos.ConsultarDetalleComic(id).Results.FirstOrDefault(),
                Personajes = _serviciosExternos.ConsultarPersonajesComic(id).Results.ToList()
            });
        }
    }
}
