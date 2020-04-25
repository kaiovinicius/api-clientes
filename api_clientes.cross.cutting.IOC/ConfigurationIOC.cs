using api_clientes.application.Abstracts;
using api_clientes.application.Concrets;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.cross.cutting.Map;
using api_clientes.Data_Acess.Abstracts.Repositories;
using api_clientes.domain.Abstracts;
using api_clientes.domain.Services;
using api_clientes.repository;
using Autofac;

namespace api_clientes.cross.cutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClienteApplicationService>().As<IClienteApplicationService>();
            builder.RegisterType<ContatoApplicationService>().As<IContatoApplicationService>();

            builder.RegisterType<ClienteService>().As<IClienteService>();
            builder.RegisterType<ContatoService>().As<IContatoService>();

            builder.RegisterType<ClienteRepository>().As<IClienteRepository>();
            builder.RegisterType<ContatoRepository>().As<IContatoRepository>();

            builder.RegisterType<MapperCliente>().As<IMapperCliente>();
            builder.RegisterType<MapperContato>().As<IMapperContato>();
        }
    }
}
