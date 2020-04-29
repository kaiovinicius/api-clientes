
using api_clientes.application.DTO.Models;
using api_clientes.domain.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Abstracts
{
    public interface IMapperEndereco
    {
        Endereco DTOToEntity(EnderecoDTO enderecoDTO);
        EnderecoDTO EntityToDTO(Endereco endereco);
        IEnumerable<EnderecoDTO> ListEntityToListDTO(IEnumerable<Endereco> enderecos);
    }
}
