using api_customer.application.Abstracts;
using api_customer.application.Concrets;
using api_customer.cross.cutting.Abstracts;
using api_customer.cross.cutting.Map;
using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.domain.core.Abstracts.Repositories.DbEnderecos;
using api_customer.domain.core.Abstracts.Services;
using api_customer.domain.Services;
using api_customer.repository;
using api_customer.services.Services;
using Autofac;

namespace api_customer.cross.cutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomereApplicationService>().As<ICustomerApplicationService>();
            builder.RegisterType<ContactApplicationService>().As<IContactApplicationService>();
            builder.RegisterType<AddressApplicationService>().As<IAddressApplicationService>();

            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<ContactService>().As<IContactService>();
            builder.RegisterType<AddressService>().As<IAddressService>();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ContactRepository>().As<IContactRepository>();
            builder.RegisterType<AddressRepository>().As<IAdressRepository>();

            builder.RegisterType<CustomerMapper>().As<CustomerIMapper>();
            builder.RegisterType<ContactMapper>().As<ContactIMapper>();
            builder.RegisterType<AddressMapper>().As<AddressIMapper>();
        }
    }
}
