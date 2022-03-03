using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolicitudesDanielaHernandez.Models;
using SolicitudesDanielaHernandez.Data;

namespace SolicitudesDanielaHernandez.Repositorio
{
    public class MiRepositorio : IRepositorio
    {
        private SolicitudContext _context;

        public MiRepositorio(SolicitudContext context)
        {
            _context = context;
        }

        public IEnumerable<Solicitud> ObtenerSolicitud()
        {
            return _context.Solicitudes.ToList();
        }

        public void CrearSolicitud(Solicitud solicitud)
        {
            _context.Add(new Solicitud() { Nombre = solicitud.Nombre, Apellido = solicitud.Apellido, Identificacion = solicitud.Identificacion, Edad = solicitud.Edad, Casa = solicitud.Casa});
            _context.SaveChanges();
        }

        public void ModificarSolicitud(Solicitud solicitud)
        {
            _context.Solicitudes.Update(solicitud);
            _context.SaveChanges();
        }

        public void EliminarSolicitud(int id)
        {
            var person = _context.Solicitudes.SingleOrDefault(m => m.SolicitudId == id);
            _context.Solicitudes.Remove(person);
            _context.SaveChanges();
        }

        public Solicitud BuscarSolicitud(int id)
        {
            var solicitud = _context.Solicitudes.SingleOrDefault(m => m.SolicitudId == id);
            return solicitud;
        }
    }
}
