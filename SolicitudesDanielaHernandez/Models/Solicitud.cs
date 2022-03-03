using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SolicitudesDanielaHernandez.Models
{
    public class Solicitud
    {
        public int SolicitudId { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor indique su nombre")]
        [StringLength(20, ErrorMessage = "Longitud máxima 20")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido:")]
        [Required(ErrorMessage = "Por favor indique su apellido")]
        [StringLength(20, ErrorMessage = "Longitud máxima 20")]
        public string Apellido { get; set; }

        [Display(Name = "Identificación:")]
        [Required(ErrorMessage = "Por favor indique su identificación")]
        [Range(0, 99999999, ErrorMessage = "Su identificación no puede tener más de 10 dígitos")]
        public int Identificacion { get; set; }

        [Display(Name = "Edad:")]
        [Required(ErrorMessage = "Por favor indique su edad")]
        [Range(0, 99, ErrorMessage = "Su edad no puede tener más de 2 dígitos")]
        public int Edad { get; set; }

        [Display(Name = "Casa:")]
        public string Casa { get; set; }

    }
}
