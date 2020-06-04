
using api_customer.application.DTO.Models;
using api_customer.domain.Entities;
using api_customer.grpc.services.endereco.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Abstracts
{
    public interface AddressIMapper
    {
        Address DTOToEntity(AddressDTO enderecoDTO);
        AddressDTO EntityToDTO(Address endereco);
        IEnumerable<AddressDTO> ListEntityToListDTO(IEnumerable<Address> enderecos);
        AddressDTO ProtoToDTO(EnderecoGet proto);
        EnderecoGet DTOToProto(AddressDTO enderecoDTO);
        IEnumerable<AddressDTO> ListProtoToListDTO(IEnumerable<EnderecoGet> enderecos);
    }
}
