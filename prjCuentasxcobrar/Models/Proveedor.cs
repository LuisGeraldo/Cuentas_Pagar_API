using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCuentasxcobrar.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }
        public int IdTipoPersona { get; set; }

        [ForeignKey("IdTipoPersona")]
        public TipoPersona TipoPersona { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; } //RNC o Cedula
        public double Balance { get; set; }
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
        public IEnumerable<DocumentoPorPagar> DocumentoPorPagar { get; set; }
    }
}
