using api_clientes_ma9.application.dto;
using System.Collections.Generic;

namespace api_clientes_ma9.application.abstracts
{
    public interface IContatoApplicationService
    {
        IEnumerable<ContatoDTO> Listar();

        ContatoDTO Obter(int? id);

        void Inserir(ContatoDTO clienteDTO);

        void Alterar(ContatoDTO clienteDTO);

        void Excluir(int? id);
    }
}
