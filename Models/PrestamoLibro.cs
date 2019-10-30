using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class PrestamoLibro
    {
        public int PrestamoId { get; set; }
        public int LibroId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [NotMapped]
        public Prestamo Prestamo { get; set; }

        [NotMapped]
        public Libro Libro { get; set; }
    }
}