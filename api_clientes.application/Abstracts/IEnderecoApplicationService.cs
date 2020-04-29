using api_clientes.application.DTO.Models;
using System.Collections.Generic;

namespace api_clientes.application.Abstracts
{
    public interface IEnderecoApplicationService
    {
        IEnumerable<EnderecoDTO> Listar();

        EnderecoDTO Obter(int? id);

        void Inserir(EnderecoDTO enderecoDTO);

        void Alterar(EnderecoDTO enderecoDTO);

        void Excluir(int? id);
    }
}
