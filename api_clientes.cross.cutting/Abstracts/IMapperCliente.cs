using api_clientes.application.DTO.Models;
using api_clientes.domain.Entities;
using api_clientes.grpc.services.cliente.Protos;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperCliente
    {
        Cliente DTOToEntity(ClienteDTO clienteDTO);
        ClienteGet DTOToProto(ClienteDTO clienteDTO);
        ClienteDTO EntityToDTO(Cliente Cliente);
        ClienteDTO ProtoToDTO(ClienteGet proto);
        IEnumerable<ClienteDTO> ListEntityToListDTO(IEnumerable<Cliente> clientes);
        IEnumerable<ClienteDTO> ListProtoToListDTO(IEnumerable<ClienteGet> clientes);
    }
}