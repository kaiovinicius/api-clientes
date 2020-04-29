using api_clientes.application.Abstracts;
using api_clientes.application.Concrets;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.cross.cutting.Map;
using api_clientes.domain.core.Abstracts.Repositories.DbClientes;
using api_clientes.domain.core.Abstracts.Repositories.DbEnderecos;
using api_clientes.domain.core.Abstracts.Services;
using api_clientes.domain.Services;
using api_clientes.repository;
using api_clientes.services.Services;
using Autofac;

namespace api_clientes.cross.cutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteApplicationService>().As<IClienteApplicationService>();
            builder.RegisterType<ContatoApplicationService>().As<IContatoApplicationService>();
            builder.RegisterType<EnderecoApplicationService>().As<IEnderecoApplicationService>();

            builder.RegisterType<ClienteService>().As<IClienteService>();
            builder.RegisterType<ContatoService>().As<IContatoService>();
            builder.RegisterType<EnderecoService>().As<IEnderecoService>();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<ContatoRepository>().As<IContatoRepository>();
            builder.RegisterType<EnderecoRepository>().As<IEnderecoRepository>();

            builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            builder.RegisterType<MapperContato>().As<IMapperContato>();
            builder.RegisterType<MapperEndereco>().As<IMapperEndereco>();
        }
    }
}
