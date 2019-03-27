using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjCuentasxcobrar.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }
        public IEnumerable<Proveedor> Proveedores { get; set; }
        public IEnumerable<ConceptoPago> ConceptoPagos { get; set; }
        public IEnumerable<DocumentoPorPagar> DocumentosPorPagar { get; set; }
    }
}
