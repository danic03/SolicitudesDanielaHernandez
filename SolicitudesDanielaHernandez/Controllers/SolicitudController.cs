using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SolicitudesDanielaHernandez.Models;
using SolicitudesDanielaHernandez.Repositorio;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SolicitudesDanielaHernandez.Controllers
{
    public class SolicitudController : Controller
    {
        private IRepositorio _repositorio;

        public SolicitudController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var lista = _repositorio.ObtenerSolicitud();
            return View(lista);
        }

        [HttpGet]
        public IActionResult FormSolicitud()
        {

            return View();
        }

        [HttpPost]
        public IActionResult FormSolicitud(Solicitud solicitud)
        {

            if (ModelState.IsValid)
                
                return RedirectToAction("Create", solicitud);
              
            else
                return View(solicitud);
            
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
      
            Solicitud solicitud = _repositorio.BuscarSolicitud(id);

            if(solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);

        }

        [HttpPost, ActionName("Edit")]
        public IActionResult EditPost(Solicitud solicitud)
        {
            if(!ModelState.IsValid)
            {
                return View("Edit", solicitud);
            }

            _repositorio.ModificarSolicitud(solicitud);
            return RedirectToAction("Index");
        }

            public IActionResult Create(Solicitud solicitud)
        {
            _repositorio.CrearSolicitud(solicitud);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            _repositorio.EliminarSolicitud(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
