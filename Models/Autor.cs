using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nombres { get; set; }

        [Required, MaxLength(50)]
        public string Apellidos { get; set; }

        [NotMapped]
        public List<LibroAutor> LibrosAutores { get; set; }
    }
}