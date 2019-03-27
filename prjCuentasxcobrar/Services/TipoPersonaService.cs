using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace prjCuentasxcobrar.Services
{
    public interface ITipoPersonaService
    {
        List<TipoPersona> GetAll();
        TipoPersona GetById(int Id);
        TipoPersona Create(TipoPersona Model);
        TipoPersona Update(TipoPersona Model);
        bool Delete(int Id);
    }
    public class TipoPersonaService : ITipoPersonaService
    {
        public ApplicationDbContext _context { get; set; }
        public TipoPersonaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TipoPersona> GetAll()
        {
            return _context.TipoPersonas.ToList();
        }
        public TipoPersona GetById(int Id)
        {
            return _context.TipoPersonas.FirstOrDefault(x => x.Id == Id);
        }
        public TipoPersona Create(TipoPersona Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.TipoPersonas.Add(Model);
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
                    return Model;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public TipoPersona Update(TipoPersona Model)
        {
            try
            {
                using (var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    dbContextTransaction.Commit();
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
                    var TipoPersona = _context.TipoPersonas.FirstOrDefault(x => x.Id == Id);
                    _context.TipoPersonas.Remove(TipoPersona);
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
