using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SolicitudesDanielaHernandez.Models;

namespace SolicitudesDanielaHernandez.Repositorio
{
    public interface IRepositorio
    {
        IEnumerable<Solicitud> ObtenerSolicitud();
        void CrearSolicitud(Solicitud solicitud);
        void ModificarSolicitud(Solicitud solicitud);
        void EliminarSolicitud(int id);
        Solicitud BuscarSolicitud(int id);
    }
}
