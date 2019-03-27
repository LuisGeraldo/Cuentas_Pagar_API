using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjCuentasxcobrar.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }
        public List<Usuario> Usuarios { get; set; }
    }
}
