using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SolicitudesDanielaHernandez.Data;
using SolicitudesDanielaHernandez.Repositorio;

namespace SolicitudesDanielaHernandez
{
    public class Startup
    {
        private IConfiguration _configuration;


        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SolicitudContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepositorio, MiRepositorio>();

            services.AddMvc();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, SolicitudContext solicitudContext)
        {

            solicitudContext.Database.EnsureDeleted();
            solicitudContext.Database.EnsureCreated();

            app.UseStaticFiles();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultRoute",
                    template: "{controller=Solicitud}/{action=Index}/{id?}");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "FormSolicitud",
                    template: "{controller=Solicitud}/{action=FormSolicitud}");
            });
            
        }
    }
}
