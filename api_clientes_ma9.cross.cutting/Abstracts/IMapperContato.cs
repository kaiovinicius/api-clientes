using api_clientes_ma9.application.dto;
using api_clientes_ma9.Entities;
using System.Collections.Generic;

namespace api_clientes_ma9.cross.cutting.Abstracts
{
    public interface IMapperContato
    {
        Contato DTOToEntity(ContatoDTO contatoDTO);
        ContatoDTO EntityToDTO(Contato contato);
        IEnumerable<ContatoDTO> ListEntityToListDTO(IEnumerable<Contato> contatos);
    }
}
