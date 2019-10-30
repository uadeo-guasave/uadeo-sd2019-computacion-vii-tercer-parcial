using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class Permiso
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; }

        [Required, MaxLength(200)]
        public string Descripcion { get; set; }

        [NotMapped]
        public List<RolPermiso> RolesPermisos { get; set; }
    }
}