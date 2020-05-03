using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

//swagger
using Microsoft.OpenApi.Models;
using Proyecto_Licitacion.Global.Config.Cors;
using Proyecto_Licitacion.Global.Config.DBContext;


namespace Proyecto_Licitacion
{
    public class Startup
    {
        public static string CADENA_CONEXION = "lic";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }

        // Este método es llamado por el tiempo de ejecución. Use este método para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            /*DB*/
            services.AddDbContext<DBContextLic>( o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString(CADENA_CONEXION));
            });

            /*Swwager*/
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentation UCH",
                    Version = "v1"
                });
            });


            /*******CORS*************/
            services.AddCors(options =>
            {
                options.AddPolicy("ApiCorsPolicy", builder =>
                {
                    builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });
        }


        //Este método es llamado por el tiempo de ejecución.Use este método para configurar la canalización de solicitudes HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentation");
                o.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            /**************CORS****************/
            app.UseCors("ApiCorsPolicy");
            /********************************/

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
