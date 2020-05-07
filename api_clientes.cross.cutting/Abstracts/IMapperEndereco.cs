
using api_clientes.application.DTO.Models;
using api_clientes.domain.Entities;
using api_clientes.grpc.services.endereco.Protos;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperEndereco
    {
        Endereco DTOToEntity(EnderecoDTO enderecoDTO);
        EnderecoDTO EntityToDTO(Endereco endereco);
        IEnumerable<EnderecoDTO> ListEntityToListDTO(IEnumerable<Endereco> enderecos);
        EnderecoDTO ProtoToDTO(EnderecoGet proto);
        EnderecoGet DTOToProto(EnderecoDTO enderecoDTO);
        IEnumerable<EnderecoDTO> ListProtoToListDTO(IEnumerable<EnderecoGet> enderecos);
    }
}
