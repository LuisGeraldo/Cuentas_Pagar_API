using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace prjCuentasxcobrar.Services
{
    public interface IUsuarioService
    {
        List<Usuario> GetAll();
        Usuario GetById(int Id);
        Usuario GetUsuarioByEmailAndPassword(string Email, string Passsword);
        Usuario Create(Usuario Model);
        Usuario Update(Usuario Model);
        Usuario Delete(int Id);
    }
    public class UsuarioService : IUsuarioService
    {
        public ApplicationDbContext _context { get; set; }

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }
        public Usuario Create(Usuario Model)
        {
            try
            {
                _context.Usuario.Add(Model);
                _context.SaveChanges();
                return Model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            return _context.Usuario.ToList();
        }        

        public Usuario GetUsuarioByEmailAndPassword(string Email, string Passsword)
        {
            var user = _context
                             .Usuario
                             .FirstOrDefault(x => x.Email.Equals(Email) && x.Password.Equals(Passsword));

            return user;
        }

        public Usuario GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Usuario Update(Usuario Model)
        {
            throw new NotImplementedException();
        }
    }
}
