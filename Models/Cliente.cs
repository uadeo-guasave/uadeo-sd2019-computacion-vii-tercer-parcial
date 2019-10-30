using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Nombre { get; set; }

        [Required, MaxLength(50)]
        public string Apellidos { get; set; }

        [Required, MaxLength(200)]
        public string Domicilio { get; set; }

        [Required, MaxLength(30)]
        public string Telefono { get; set; }

        [Required, MaxLength(200)]
        public string CorreoElectronico { get; set; }

        [NotMapped]
        public List<Prestamo> Prestamos { get; set; }
    }
}