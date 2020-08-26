using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreProduct.Data;

namespace NetCoreProduct
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
            // Criação da aplicação:
            // dotnet new mvc

            // Publicação da aplicação:
            // dotnet publish --configuration Release --output dist

            // Criação do volume que armazenará localmente os dados
            // $ docker volume create ProductData

            // Criação do container "mysql":
            // $ docker container run -d --name mysql -v ProductData:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345678 -e bind-address=0.0.0.0 mysql

            // Criação da imagem da aplicação criada utilizando o arquivo Dockerfile:
            // $ docker image build -t netcoreproduct:2.0.0 .

            // Obtenção das VARIÁVEIS DE AMBIENTE utilizadas para a criação do container da aplicação:

            // 1. DBHOST: representa o IP do container na rede bridge do Docker, e é obtido inspecionando a seção "Containers:IPv4Address" do container "mysql":
            // $ docker inspect network bridge

            // 2. DBPORT: é obtida inspecionando a seção "Config:ExposedPorts" do container "mysql":
            // $ docker container inspect mysql

            // 3. DBPASSWORD: deve ter o mesmo valor da variável MYSQL_ROOT_PASSWORD utilizada na criação do container "mysql".

            // Criação do container da aplicação:
            // $ docker container run -d --name netcoreproduct -p 3000:80 -e DBHOST=172.17.0.2 -e DBPASSWORD=12345678 -e DBPORT=3306 netcoreproduct:2.0.0

            // Acessar http://192.168.99.100:3000/

            var host = Configuration["DBHOST"] ?? "127.0.0.1";
            var password = Configuration["DBPASSWORD"] ?? "12345678";
            var port = Configuration["DBPORT"] ?? "80";

            services.AddDbContext<AppDbContext>(options => options.UseMySQL(
                $"Server={host};Port={port};Database=ProductDB;Uid=root;Pwd={password};"));

            services.AddScoped<IProductRepository, ProductRepository>();
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
