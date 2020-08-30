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
            // Criação da aplicação MVC:
            // dotnet new mvc

            // Publicação da aplicação MVC:
            // dotnet publish --configuration Release --output dist

            // Criação da imagem da aplicação MVC criada utilizando o arquivo Dockerfile:
            // $ docker image build -t netcoreproduct:2.0.0 .

            // Criação do volume que armazenará localmente o banco de dados:
            // $ docker volume create ProductData

            // Criação do container de banco de dados e da aplicação MVC utilizando a rede bridge padrão do Docker:

                // Criação do container de banco de dados. Não existe mapeamento de portas, portanto o banco de dados não pode ser acessado via host, apenas via rede bridge padrão:
                // $ docker container run -d --name mysql -v ProductData:/var/lib/mysql -e MYSQL_ROOT_PASSWORD=12345678 -e bind-address=0.0.0.0 mysql
                
                // Obtenção das VARIÁVEIS DE AMBIENTE utilizadas para a criação do container da aplicação MVC:

                // 1. DBHOST: representa o IP do container, e é obtido inspecionando a seção "Containers:IPv4Address" do container de banco de dados:
                // $ docker network inspect bridge

                // 2. DBPORT: é obtida inspecionando a seção "Config:ExposedPorts" do container de banco de dados:
                // $ docker container inspect mysql

                // 3. DBPASSWORD: deve ter o mesmo valor da variável MYSQL_ROOT_PASSWORD utilizada na criação do container de banco de dados.

                // Criação do container da aplicação MVC, com mapeamento de portas entre host e container:
                // $ docker container run -d --name netcoreproduct -p 3000:80 -e DBHOST=172.20.0.2 -e DBPASSWORD=12345678 -e DBPORT=3306 netcoreproduct:2.0.0

            // Criação do container de banco de dados e da aplicação MVC utilizando redes personalizadas do Docker:

                // Rede que receberá requisições HTTP dos containeres MVC:
                // $ docker network create front-end

                // Rede que receberá as consultas de banco de dados entre containeres MVC e MySQL:
                // $ docker network create back-end

                // Criação do container de banco de dados. Não existe mapeamento de portas, portanto o banco de dados não pode ser acessado via host, apenas via rede "back-end":
                // $ docker container run -d --name mysql -v ProductData:/var/lib/mysql --network back-end -e MYSQL_ROOT_PASSWORD=12345678 -e bind-address=0.0.0.0 mysql

                // Criação dos containeres da aplicação MVC, associando-os à rede "back-end". Não existe mapeamento de portas, pois o responsável por mapeamento de portas será o container de load-balancer:
                // $ docker container create --name netcoreproduct-01 --network back-end -e DBHOST=mysql -e DBPASSWORD=12345678 -e DBPORT=3306 netcoreproduct:2.0.0
                // $ docker container create --name netcoreproduct-02 --network back-end -e DBHOST=mysql -e DBPASSWORD=12345678 -e DBPORT=3306 netcoreproduct:2.0.0
                // $ docker container create --name netcoreproduct-03 --network back-end -e DBHOST=mysql -e DBPASSWORD=12345678 -e DBPORT=3306 netcoreproduct:2.0.0

                // Conecta cada container da aplicação MVC na rede "front-end":
                // $ docker network connect front-end netcoreproduct-01
                // $ docker network connect front-end netcoreproduct-02
                // $ docker network connect front-end netcoreproduct-03

                // Inicia os containeres criados:
                // $ docker container start netcoreproduct-01 netcoreproduct-02 netcoreproduct-03

                // Criação do container de load-balancer utilizando um arquivo de configuração no host:
                // $ docker container run -d --name load-balancer --network front-end -v /d/Projects/Docker/NetCoreProduct/haproxy.cfg:/usr/local/etc/haproxy/haproxy.cfg -p 3200:80 haproxy

            // Acessar http://192.168.99.100:3200/

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
