using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using prjCuentasxcobrar.Data;
using prjCuentasxcobrar.Services;
using System.Text;

namespace prjCuentasxcobrar
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Entity Framework Configuration
            //Entity Framework configurtion

            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["connectionStrings:AzureConnectionString"]));

            #endregion

            #region Configuration Dependency Injection
            //Dependency Injection Configuration

            services.AddTransient<IEstadoService, EstadoService>();
            services.AddTransient<IConceptoPagoService, ConceptoPagoService>();
            services.AddTransient<ITipoPersonaService, TipoPersonaService>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IDocumentoPorPagarService, DocumentoPorPagarService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IAccountService, AccountService>();

            #endregion

            #region Configuration JWT
            //JWT Support configuration

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["ConfigurationToken:Issuer"],
                        ValidAudience = Configuration["ConfigurationToken:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["ConfigurationToken:Key"]))
                    };
            });
            #endregion

            #region Cofiguration Json result
            //Configuracion del Json result

            services.AddMvc().AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling
                        = Newtonsoft.Json.ReferenceLoopHandling.Ignore).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            app.UseCors(x => x
               .AllowAnyHeader()
               .AllowAnyOrigin()
               .AllowAnyMethod());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
