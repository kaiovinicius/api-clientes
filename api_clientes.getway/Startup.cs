using api_clientes.cross.cutting.IOC;
using api_clientes.data;
using api_clientes.grpc.services.cliente.Protos;
using api_clientes.grpc.services.endereco.Protos;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace api_clientes.getway
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
            services.AddDbContext<ClientesContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Clientes_DbConnection")));

            services.AddDbContext<EnderecosContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("Enderecos_DbConnection")));

            services.AddControllersWithViews();

            services.AddGrpcClient<ClienteService.ClienteServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:5001");
            });

            services.AddGrpcClient<ContatoService.ContatoServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:5001");
            });

            services.AddGrpcClient<EnderecoService.EnderecoServiceClient>(o =>
            {
                o.Address = new Uri("https://localhost:5002");
            });
        }

        public void ConfigureContainer(ContainerBuilder Builder)
        {
            Builder.RegisterModule(new ModuleIOC());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
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
