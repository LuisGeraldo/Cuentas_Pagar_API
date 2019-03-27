using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace prjCuentasxcobrar.Models
{
    public class TipoPersona
    {
        [Key]
        public int Id { get; set; }
        
        [StringLength(100)]
        [Required(ErrorMessage = "El nombre del tipo de persona es requerido")]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }
        public IEnumerable<Proveedor> TipoPersonas { get; set; }
    }
}
