using Microsoft.EntityFrameworkCore;
using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjCuentasxcobrar.Services
{
    public interface IProveedorService
    {
        List<Proveedor> GetAll();
        Proveedor GetById(int Id);
        Proveedor Create(Proveedor Model);
        Proveedor Update(Proveedor Model);
        bool Delete(int Id);
    }
    public class ProveedorService : IProveedorService
    {
        public ApplicationDbContext _context { get; set; }
        public ProveedorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Proveedor Create(Proveedor Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                   _context.Proveedores.Add(Model);
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
                    var Proveedor = _context.Proveedores
                                            .FirstOrDefault(x => x.Id == Id);

                    _context.Proveedores
                            .Remove(Proveedor);

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
        public List<Proveedor> GetAll()
        {
            return _context.Proveedores
                           .Include(x => x.Estado)
                           .ToList();
        }
        public Proveedor GetById(int Id)
        {
            return _context.Proveedores
                           .FirstOrDefault(x => x.Id == Id);
        }
        public Proveedor Update(Proveedor Model)
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

                    return Model;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
