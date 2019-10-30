using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class LibroAutor
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }

        [NotMapped]
        public Libro Libro { get; set; }
        
        [NotMapped]
        public Autor Autor { get; set; }
    }
}