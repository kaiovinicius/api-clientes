using api_customer.application.DTO.Models;
using api_customer.domain.Entities;
using api_customer.grpc.services.customer.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Abstracts
{
    public interface CustomerIMapper
    {
        Customer DTOToEntity(CustomerDTO clienteDTO);
        ClienteGet DTOToProto(CustomerDTO clienteDTO);
        CustomerDTO EntityToDTO(Customer Cliente);
        CustomerDTO ProtoToDTO(ClienteGet proto);
        IEnumerable<CustomerDTO> ListEntityToListDTO(IEnumerable<Customer> clientes);
        IEnumerable<CustomerDTO> ListProtoToListDTO(IEnumerable<ClienteGet> clientes);
    }
}