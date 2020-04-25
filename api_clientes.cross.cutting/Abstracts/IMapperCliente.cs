using api_clientes.application.Models;
using api_clientes.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperCliente
    {
        Cliente DTOToEntity(ClienteDTO clienteDTO);
        ClienteDTO EntityToDTO(Cliente Cliente);
        IEnumerable<ClienteDTO> ListClienteToDTO(IEnumerable<Cliente> clientes);
    }
}