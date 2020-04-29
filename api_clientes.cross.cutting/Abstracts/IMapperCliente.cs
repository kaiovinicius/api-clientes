using api_clientes.application.DTO.Models;
using api_clientes.domain.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperCliente
    {
        Cliente DTOToEntity(ClienteDTO clienteDTO);
        ClienteDTO EntityToDTO(Cliente Cliente);
        IEnumerable<ClienteDTO> ListEntityToListDTO(IEnumerable<Cliente> clientes);
    }
}