using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreStudent.Context;

namespace NetCoreStudent
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
            // Aplicação criada através da linha de comando:
            // dotnet new mvc

            // Aplicação publicada através da linha de comando:
            // dotnet publish --configuration Release --output dist

            // O host representa o IP do container "mysql-student" na rede bridge do Docker, e é obtido através do seguinte comando:
            // $ docker network ls

            // Na criação do container que conterá essa aplicação, variáveis de ambiente são passadas como parâmetro:
            // $ docker container run -d --name mvc-student -p 5000:80 -e DBHOST=172.17.0.2 -e DBPASSWORD=123456 -e DBPORT=3306 appstudent:1.0
            var host = Configuration["DBHOST"] ?? "127.0.0.1";
            var password = Configuration["DBPASSWORD"] ?? "pwd";
            var port = Configuration["DBPORT"] ?? "80";

            services.AddDbContext<StudentContext>(options => options
                .UseMySQL($"server={host};userid=root;pwd={password};port={port};database=StudentDB"));
                
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
