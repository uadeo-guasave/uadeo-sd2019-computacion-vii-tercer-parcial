using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Jornada
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaDeApertura { get; set; }

        [Required]
        public DateTime FechaDeCierre { get; set; }

        [Required]
        public int UsuarioId { get; set; }


        [NotMapped]
        public List<Prestamo> Prestamos { get; set; }
    }
}