using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Shire.Api
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
            services.AddCors(options =>
           {
               options.AddPolicy("AllowAll",
                   corsBuilder =>
                   {
                       corsBuilder
                           .WithOrigins("localhost:3000")
                           .WithOrigins("https://www.polskieradio.pl")
                           .WithOrigins("http://www.polskieradio.pl")
                           .WithOrigins("https://polskieradio.pl")
                           .WithOrigins("http://polskieradio.pl")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                   });
           });

            services.AddControllers();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Shrie? Shrie.", Version = "v1" }); });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "lato");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
