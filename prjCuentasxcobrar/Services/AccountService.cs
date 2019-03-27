using System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using prjCuentasxcobrar.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace prjCuentasxcobrar.Services
{
    public interface IAccountService
    {
        string CreateToken(Usuario Model);
        Usuario Login(Login Model);
    }
    public class AccountService : IAccountService
    {
        public IConfiguration _config;
        IUsuarioService _UsuarioService;
        public AccountService(IConfiguration config, IUsuarioService UsuarioService)
        {
            _config = config;
            _UsuarioService = UsuarioService;
        }
        public string CreateToken(Usuario Model)
        {
                var Claims = new[]
                {
                new Claim("id", Model.Id.ToString()),
                new Claim("Email", Model.Email),
                new Claim("RolId", Model.IdRol.ToString())
                };

                var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["ConfigurationToken:Key"]));
                var Creds = new SigningCredentials(Key, SecurityAlgorithms.HmacSha256);

                var Token = new JwtSecurityToken(_config["ConfigurationToken:Issuer"],
                  _config["ConfigurationToken:Issuer"],
                  Claims,
                  expires: DateTime.Now.AddDays(1),
                  signingCredentials: Creds);

                return new JwtSecurityTokenHandler().WriteToken(Token);
        }


        public Usuario Login(Login Model)
        {
            Usuario usuario = null;

            try
            {
                usuario = _UsuarioService.GetUsuarioByEmailAndPassword(Model.Email, Model.Password);
                if (usuario != null)
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
            return usuario;
        }
    }
}
