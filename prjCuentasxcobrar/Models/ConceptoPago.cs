using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCuentasxcobrar.Models
{
    public class ConceptoPago
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "El nombre del concepto de pago es requerido")]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
        public IEnumerable<DocumentoPorPagar> DocumentosPorPagar { get; set; }
    }
}
