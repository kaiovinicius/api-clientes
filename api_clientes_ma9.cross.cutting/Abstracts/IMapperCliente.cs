using api_clientes_ma9.application.Models;
using api_clientes_ma9.Entities;
using System.Collections.Generic;

namespace api_clientes_ma9.cross.cutting.Abstracts
{
    public interface IMapperCliente
    {
        Cliente DTOToEntity(ClienteDTO clienteDTO);
        ClienteDTO EntityToDTO(Cliente Cliente);
        IEnumerable<ClienteDTO> ListClienteToDTO(IEnumerable<Cliente> clientes);
    }
}