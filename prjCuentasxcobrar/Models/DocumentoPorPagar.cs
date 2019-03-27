using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prjCuentasxcobrar.Models
{
    public class DocumentoPorPagar
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El numero de documento es requido")]
        [StringLength(100)]
        public string NoDocumento { get; set; }

        [Required(ErrorMessage = "El numero de factura es requido")]
        [StringLength(100)]
        public string NoFactura { get; set; }
        public int IdConceptoPago { get; set; }

        [ForeignKey("IdConceptoPago")]
        public ConceptoPago ConceptoPago { get; set; }
        public DateTime Fecha { get; set; }
        public double Monto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdProveedor { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedor Proveedor { get; set; }
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado Estado { get; set; }
    }
}
