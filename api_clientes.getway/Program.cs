using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using api_clientes.grpc.services.cliente.Protos;
using api_clientes.grpc.services.endereco.Protos;
using GrpcJsonTranscoder;
using GrpcJsonTranscoder.Grpc;

namespace api_clientes.getway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await BuildWebHost(args).RunAsync();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseKestrel()
        .ConfigureAppConfiguration((hostingContext, config) =>
        {
            config
                .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                .AddJsonFile("ocelot.json")
                .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                //.AddJsonFile("./Routes/appsettings.json", true, true)
                //.AddJsonFile($"./Routes/appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                //.AddJsonFile("./Routes/clientes.json")
                //.AddJsonFile($"./Routes/clientes.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                //.AddJsonFile("./Routes/contatos.json")
                //.AddJsonFile($"./Routes/contatos.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                //.AddJsonFile("./Routes/enderecos.json")
                //.AddJsonFile($"./Routes/enderecos.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();
        })
        .ConfigureServices(services =>
        {
            services.AddOcelot();
            services.AddHttpContextAccessor();
            
            services.AddGrpcJsonTranscoder(() => new GrpcAssemblyResolver().ConfigGrpcAssembly(
                services.BuildServiceProvider().GetService<ILogger<GrpcAssemblyResolver>>(), 
                typeof(ClienteService.ClienteServiceBase).Assembly));
            
            services.AddGrpcJsonTranscoder(() => new GrpcAssemblyResolver().ConfigGrpcAssembly(
                services.BuildServiceProvider().GetService<ILogger<GrpcAssemblyResolver>>(), 
                typeof(EnderecoService.EnderecoServiceBase).Assembly));
        })
        .Configure(app =>
        {
            var configuration = new OcelotPipelineConfiguration
            {
                PreQueryStringBuilderMiddleware = async (ctx, next) =>
                {
                    // https://stackoverflow.com/questions/54960613/how-to-create-callcredentials-from-sslcredentials-and-token-string
                    await ctx.HandleGrpcRequestAsync(next/*, new SslCredentials(File.ReadAllText("Certs/server.crt"))*/);
                }
            };

            app.UseOcelot(configuration).Wait();
        })
        .Build();
    }
}
