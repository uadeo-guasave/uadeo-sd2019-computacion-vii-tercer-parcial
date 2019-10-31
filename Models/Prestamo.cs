using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Prestamo
    {
        public int Id { get; set; }

        [Required]
        public DateTime FechaDeSalida { get; set; }

        [Required]
        public DateTime FechaDeRegreso { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int JornadaId { get; set; }

        [NotMapped]
        public Jornada Jornada { get; set; }

        [NotMapped]
        public Cliente Cliente { get; set; }

        [NotMapped]
        public List<PrestamoLibro> PrestamosLibros { get; set; }

    }
}