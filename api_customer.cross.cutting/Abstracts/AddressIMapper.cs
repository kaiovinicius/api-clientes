
using api_customer.application.DTO.Models;
using api_customer.domain.Entities;
using api_customer.grpc.services.address.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Abstracts
{
    public interface AddressIMapper
    {
        Address DTOToEntity(AddressDTO addressDTO);
        AddressDTO EntityToDTO(Address address);
        IEnumerable<AddressDTO> ListEntityToListDTO(IEnumerable<Address> addresses);
        AddressDTO ProtoToDTO(AddressGet proto);
        AddressGet DTOToProto(AddressDTO addressDTO);
        IEnumerable<AddressDTO> ListProtoToListDTO(IEnumerable<AddressGet> addresses);
    }
}
