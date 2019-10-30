using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Rol
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [NotMapped]
        public List<Usuario> Usuarios { get; set; }

        [NotMapped]
        public List<RolPermiso> RolesPermisos { get; set; }
    }
}