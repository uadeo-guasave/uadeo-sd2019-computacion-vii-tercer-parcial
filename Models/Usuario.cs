using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, MaxLength(12)]
        public string Nombre { get; set; }

        [Required, MaxLength(200)]
        public string Contraseña { get; set; }

        [Required, MaxLength(200)]
        public string CorreoElectronico { get; set; }

        [Required, MaxLength(50)]
        public string Nombres { get; set; }

        [Required, MaxLength(50)]
        public string Apellidos { get; set; }

        [MaxLength(200)]
        public string RecordatorioDeContraseña { get; set; }

        [Required]
        public Estado Estado { get; set; } = Estado.Activo;

        [Required]
        public int RolId { get; set; }

        [NotMapped]
        public Rol Rol { get; set; }
    }

    public enum Estado
    {
        Activo = 1,
        Inactivo = 0
    }
}