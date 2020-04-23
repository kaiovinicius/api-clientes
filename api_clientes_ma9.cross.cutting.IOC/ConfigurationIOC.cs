using api_clientes_ma9.application.abstracts;
using api_clientes_ma9.application.Concrets;
using api_clientes_ma9.cross.cutting.Abstracts;
using api_clientes_ma9.cross.cutting.Map;
using api_clientes_ma9.Data_Acess.Abstracts.Repositories;
using api_clientes_ma9.domain.Abstracts;
using api_clientes_ma9.domain.Services;
using api_clientes_ma9.repository;
using Autofac;

namespace api_clientes_ma9.cross.cutting.IOC
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
