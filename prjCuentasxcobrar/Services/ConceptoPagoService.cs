using Microsoft.EntityFrameworkCore;
using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjCuentasxcobrar.Services
{
    public interface IConceptoPagoService
    {
        List<ConceptoPago> GetAll();
        ConceptoPago GetById(int Id);
        ConceptoPago Create(ConceptoPago Model);
        ConceptoPago Update(ConceptoPago Model);
        bool Delete(int Id);
    }
    public class ConceptoPagoService : IConceptoPagoService
    {
        public ApplicationDbContext _context { get; set; }

        public ConceptoPagoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ConceptoPago> GetAll()
        {
            return _context.ConceptoPagos
                           .Include(x => x.Estado)
                           .ToList();
        }

        public ConceptoPago GetById(int Id)
        {
            return _context.ConceptoPagos
                           .Include(x => x.Estado)
                           .FirstOrDefault(x => x.Id == Id);
        }

        public ConceptoPago Create(ConceptoPago Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.ConceptoPagos.Add(Model);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    Model.Estado = _context
                                  .Estados
                                  .Find(Model.IdEstado);

                    return Model;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ConceptoPago Update(ConceptoPago Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    dbContextTransaction.Commit();

                    Model.Estado = _context
                                   .Estados
                                   .Find(Model.IdEstado);

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
                    var ConceptoPago = _context
                                      .ConceptoPagos
                                      .FirstOrDefault(x => x.Id == Id);

                    _context.ConceptoPagos.Remove(ConceptoPago);
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
