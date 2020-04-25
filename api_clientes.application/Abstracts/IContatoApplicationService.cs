using api_clientes.application.Models;
using System.Collections.Generic;

namespace api_clientes.application.Abstracts
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
