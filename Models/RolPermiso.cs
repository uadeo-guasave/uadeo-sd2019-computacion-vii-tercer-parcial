using System.ComponentModel.DataAnnotations.Schema;

namespace Tercer_Parcial.Models
{
    public class RolPermiso
    {
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        [NotMapped]
        public Rol Rol { get; set; }

        [NotMapped]
        public Permiso Permiso { get; set; }
    }
}