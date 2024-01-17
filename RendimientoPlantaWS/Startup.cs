using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RendimientoPlantaWS.Repositories;

namespace RendimientoPlantaWS
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
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<FincaRepository>();
            services.AddScoped<LineaRepository>();
            services.AddScoped<PermisoRepository>();
            services.AddScoped<DelPermisoRepository>();
            services.AddScoped<JornadaRepository>();
            services.AddScoped<RecesoRepository>();
            services.AddScoped<MotivoRepository>();
            services.AddScoped<OperarioRepository>();
            services.AddScoped<OperarioLineaRepository>();
            services.AddScoped<TallosAsignadosRepository>();
            services.AddScoped<TallosDesasignadosRepository>();
            services.AddScoped<CierreLineaRepository>();
            services.AddScoped<CierreOperarioRepository>();
            services.AddScoped<RendimientoRepository>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
