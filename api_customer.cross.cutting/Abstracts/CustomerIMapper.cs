using api_customer.application.DTO.Models;
using api_customer.domain.Entities;
using api_customer.grpc.services.customer.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Abstracts
{
    public interface CustomerIMapper
    {
        Customer DTOToEntity(CustomerDTO customerDTO);
        CustomerGet DTOToProto(CustomerDTO customerDTO);
        CustomerDTO EntityToDTO(Customer Customer);
        CustomerDTO ProtoToDTO(CustomerGet proto);
        IEnumerable<CustomerDTO> ListEntityToListDTO(IEnumerable<Customer> customers);
        IEnumerable<CustomerDTO> ListProtoToListDTO(IEnumerable<CustomerGet> customers);
    }
}