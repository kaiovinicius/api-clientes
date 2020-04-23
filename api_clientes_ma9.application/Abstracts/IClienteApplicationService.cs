using api_clientes_ma9.application.dto;
using System;
using System.Collections.Generic;

namespace api_clientes_ma9.application.abstracts
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
