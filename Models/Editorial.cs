using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Editorial
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Nombre { get; set; }

        [Required, MaxLength(30)]
        public string Telefono { get; set; }

        [Required, MaxLength(200)]
        public string Domicilio { get; set; }

        [Required, MaxLength(100)]
        public string PaisDeOrigen { get; set; }

        [NotMapped]
        public List<Libro> Libros { get; set; }
    }
}