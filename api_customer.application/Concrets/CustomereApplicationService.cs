using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.grpc.services.customer.Protos;
using System.Collections.Generic;

namespace api_customer.application.Concrets
{
    public class CustomereApplicationService : ICustomerApplicationService
    {
        #region Variables
        private readonly CustomerIMapper _mapperCustomer;
        private readonly CustomerService.CustomerServiceClient _serviceGrpcCustomer;
        #endregion

        #region Constructor
        public CustomereApplicationService(CustomerIMapper mapperCustomer, CustomerService.CustomerServiceClient serviceGrpcCustomer)
        {
            this._mapperCustomer = mapperCustomer;
            this._serviceGrpcCustomer = serviceGrpcCustomer;
        }
        #endregion

        public IEnumerable<CustomerDTO> List()
        {
            var customers = _serviceGrpcCustomer.List(new Empty{ });

            return _mapperCustomer.ListProtoToListDTO(customers.Items);
        }

        public CustomerDTO Get(int? id)
        {
            var customer = _serviceGrpcCustomer.Get(new Request { Id = id.Value });

            return _mapperCustomer.ProtoToDTO(customer);
        }

        public void Insert(CustomerDTO customerDTO)
        {
            var proto = _mapperCustomer.DTOToProto(customerDTO);

            var customer = new CustomerPost
            {
                IdAddress = proto.IdAddress,
                Name = proto.Name,
                Surname = proto.Surname,
                Cpf = proto.Cpf,
                Genre = proto.Genre.ToString()
            };

            _serviceGrpcCustomer.Insert(customer);
        }

        public void Update(CustomerDTO customerDTO)
        {
            var proto = _mapperCustomer.DTOToProto(customerDTO);

            var customer = new CustomerPut
            {   
                Id = customerDTO.Id.Value,
                IdAddress = proto.IdAddress,
                Name = proto.Name,
                Surname = proto.Surname,
                Cpf = proto.Cpf,
                Genre= proto.Genre.ToString()
            };

            _serviceGrpcCustomer.Update(customer);
        }

        public void Delete(int? id)
        {
            _serviceGrpcCustomer.Delete(new Request { Id = id.Value });
        }
    }
}
