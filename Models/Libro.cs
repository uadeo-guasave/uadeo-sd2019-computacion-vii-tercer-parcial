using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required, MaxLength(17)]
        public string Isbn { get; set; }

        [Required, MaxLength(200)]
        public string Titulo { get; set; }

        [Required]
        public int Volumen { get; set; }

        [Required]
        public double Precio { get; set; }
        
        [NotMapped]
        public List<LibroAutor> LibrosAutores { get; set; }

        [NotMapped]
        public Editorial Editorial { get; set; }

        [NotMapped]
        public List<PrestamoLibro> PrestamosLibros { get; set; }
    }
}