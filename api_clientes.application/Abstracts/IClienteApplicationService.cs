using api_clientes.application.DTO.Models;
using System.Collections.Generic;

namespace api_clientes.application.Abstracts
{
    public interface IClienteApplicationService
    {
        IEnumerable<ClienteDTO> Listar();

        ClienteDTO Obter(int? id);

        void Inserir(ClienteDTO clienteDTO);

        void Alterar(ClienteDTO clienteDTO);

        void Excluir(int? id);
    }
}
