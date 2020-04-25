using api_clientes.application.Models;
using api_clientes.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperContato
    {
        Contato DTOToEntity(ContatoDTO contatoDTO);
        ContatoDTO EntityToDTO(Contato contato);
        IEnumerable<ContatoDTO> ListEntityToListDTO(IEnumerable<Contato> contatos);
    }
}
