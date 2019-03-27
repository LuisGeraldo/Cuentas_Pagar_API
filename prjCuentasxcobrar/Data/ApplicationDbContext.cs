using Microsoft.EntityFrameworkCore;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCuentasxcobrar.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Estado> Estados { get; set; }
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<ConceptoPago> ConceptoPagos { get; set; }
        public DbSet<DocumentoPorPagar> DocumentosPorPagar { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
    }
}
