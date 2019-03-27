using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCuentasxcobrar.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        [StringLength(100)]
        public string UserName { get; set; }
        public string Email { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
        public string Token { get; set; }
        public int IdRol { get; set; }

        [ForeignKey("IdRol")]
        public Roles Rol { get; set; }
    }
}
