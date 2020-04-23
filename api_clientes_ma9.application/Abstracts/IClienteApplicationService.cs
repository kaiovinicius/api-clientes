using api_clientes_ma9.application.Models;
using System;
using System.Collections.Generic;

namespace api_clientes_ma9.application.Abstracts
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
