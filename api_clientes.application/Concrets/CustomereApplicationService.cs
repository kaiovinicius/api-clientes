using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.grpc.services.customer.Protos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace api_customer.application.Concrets
{
    public class CustomereApplicationService : ICustomerApplicationService
    {

        #region Variables
        private readonly CustomerIMapper _mapperCustomer;
        private readonly ClienteService.ClienteServiceClient _serviceGrpcCustomer;
        #endregion

        #region Constructor
        public CustomereApplicationService(CustomerIMapper mapperCustomer, ClienteService.ClienteServiceClient serviceGrpcCustomer)
        {
            this._mapperCustomer = mapperCustomer;
            this._serviceGrpcCustomer = serviceGrpcCustomer;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerDTO> List()
        {
            var customers = _serviceGrpcCustomer.Listar(new EmptyCliente { });

            return _mapperCustomer.ListProtoToListDTO(customers.Items);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CustomerDTO Get(int? id)
        {
            var customer = _serviceGrpcCustomer.Obter(new RequestCliente { Id = id.Value });

            return _mapperCustomer.ProtoToDTO(customer);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerDTO"></param>
        public void Insert(CustomerDTO customerDTO)
        {
            var proto = _mapperCustomer.DTOToProto(customerDTO);

            var customer = new ClientePost
            {
                IdEndereco = proto.IdEndereco,
                Nome = proto.Nome,
                Sobrenome = proto.Sobrenome,
                Cpf = proto.Cpf,
                Sexo = proto.Sexo.ToString()
            };

            _serviceGrpcCustomer.Inserir(customer);
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerDTO"></param>
        public void Update(CustomerDTO customerDTO)
        {
            var proto = _mapperCustomer.DTOToProto(customerDTO);

            var customer = new ClientePut
            {   
                Id = customerDTO.Id.Value,
                IdEndereco = proto.IdEndereco,
                Nome = proto.Nome,
                Sobrenome = proto.Sobrenome,
                Cpf = proto.Cpf,
                Sexo = proto.Sexo.ToString()
            };

            _serviceGrpcCustomer.Alterar(customer);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            _serviceGrpcCustomer.Excluir(new RequestCliente { Id = id.Value });
        }
        #endregion
    }
}
