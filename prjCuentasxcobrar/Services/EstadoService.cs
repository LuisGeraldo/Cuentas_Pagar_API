using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace prjCuentasxcobrar.Services
{
    public interface IEstadoService
    {
        List<Estado> GetAll();
        Estado GetById(int Id);
        Estado Create(Estado Model);
        Estado Update(Estado Model);
        bool Delete(int Id);
    }
    public class EstadoService : IEstadoService
    {
        public  ApplicationDbContext _context { get; set; }
        public EstadoService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Estado Create(Estado Model)
        {
            try
            {
                using(var dbContextTransaction = _context.Database.BeginTransaction())
                {
                    _context.Estados
                            .Add(Model);

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
                    var Estado = _context
                                 .Estados
                                 .FirstOrDefault(x => x.Id == Id);

                    _context.Estados
                            .Remove(Estado);

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
        public List<Estado> GetAll()
        {
            try
            {
                return _context.Estados.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Estado GetById(int Id)
        {
            try
            {
                return _context.Estados
                               .FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Estado Update(Estado Model)
        {
            try
            {
                _context.Entry(Model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
