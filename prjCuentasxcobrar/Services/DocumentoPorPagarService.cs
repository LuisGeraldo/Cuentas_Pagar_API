using Microsoft.EntityFrameworkCore;
using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjCuentasxcobrar.Services
{
    public interface IDocumentoPorPagarService
    {
        List<DocumentoPorPagar> GetAll();
        DocumentoPorPagar GetById(int Id);
        DocumentoPorPagar Create(DocumentoPorPagar Model);
        DocumentoPorPagar Update(DocumentoPorPagar Model);
        bool Delete(int Id);
    }
    public class DocumentoPorPagarService : IDocumentoPorPagarService
    {
        public ApplicationDbContext _context { get; set; }

        public DocumentoPorPagarService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<DocumentoPorPagar> GetAll()
        {
            return _context.DocumentosPorPagar
                           .Include(x => x.ConceptoPago)
                           .Include(x => x.Proveedor)
                           .Include(x => x.Estado)
                           .ToList();
        }

        public DocumentoPorPagar GetById(int Id)
        {
            return _context.DocumentosPorPagar
                           .FirstOrDefault(x => x.Id == Id);
        }

        public DocumentoPorPagar Create(DocumentoPorPagar Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    Model.NoDocumento = $"ND{_context.DocumentosPorPagar.Count()}{Model.IdConceptoPago}{Model.IdProveedor}";
                    Model.FechaRegistro = DateTime.Now;
                    _context.DocumentosPorPagar.Add(Model);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    Model.Estado = _context
                                   .Estados
                                   .Find(Model.IdEstado);

                    Model.ConceptoPago = _context
                                         .ConceptoPagos
                                         .Find(Model.IdConceptoPago);

                    Model.Proveedor = _context
                                     .Proveedores
                                     .Find(Model.IdProveedor);

                    return Model;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DocumentoPorPagar Update(DocumentoPorPagar Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.Entry(Model).State = EntityState.Modified;
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    Model.Estado = _context
                                  .Estados
                                  .Find(Model.IdEstado);

                    Model.ConceptoPago = _context
                                         .ConceptoPagos
                                         .Find(Model.IdConceptoPago);

                    Model.Proveedor = _context
                                     .Proveedores
                                     .Find(Model.IdProveedor);

                    return Model;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    var DocumentoPorPagar = _context
                                            .DocumentosPorPagar
                                            .FirstOrDefault(x => x.Id == Id);

                    _context.DocumentosPorPagar
                            .Remove(DocumentoPorPagar);

                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
