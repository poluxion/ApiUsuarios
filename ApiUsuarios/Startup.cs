using Microsoft.EntityFrameworkCore;
using ApiUsuarios.Models;
using Microsoft.OpenApi.Models;
using ApiUsuarios.Utilities;

namespace ApiUsuarios
{
   public class Startup
   {
      public Startup(IConfiguration configuration)
      {
         Configuration = configuration;
      }

      public IConfiguration Configuration { get; }
      public void ConfigureServices(IServiceCollection services)
      {
        services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );
         services.AddControllers();

         services.AddDbContext<UsuariosContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddAutoMapper(typeof(AutoMapperProfile));


            services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuarioServices", Version = "v1" });;

         });       
      }
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuarioServices v1"));
         }

         app.UseHttpsRedirection();

        
         app.UseDefaultFiles();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseCors();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllers();
         });
      }
   }
}
