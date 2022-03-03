using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolicitudesDanielaHernandez.Models;

namespace SolicitudesDanielaHernandez.Data
{
    public class SolicitudContext : DbContext
    {
        public SolicitudContext(DbContextOptions<SolicitudContext> options) : base(options)
        {

        }

        public DbSet<Solicitud> Solicitudes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solicitud>().HasData(
               new Solicitud
               {
                   SolicitudId = 1,
                   Nombre = "Daniela",
                   Apellido = "Hernandez",
                   Identificacion = 18817202,
                   Edad = 32,
                   Casa = "Gryffindor"
               },
               new Solicitud
               {
                   SolicitudId = 2,
                   Nombre = "Alex",
                   Apellido = "Narvaez",
                   Identificacion = 20145789,
                   Edad = 27,
                   Casa = "Gryffindor"
               });
        }
    }
}
