using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Map
{
    public class MapperContato : IMapperContato
    {
        List<ContatoDTO> contatosDTO = new List<ContatoDTO>();

        public Contato DTOToEntity(ContatoDTO contatoDTO)
        {
            if (contatoDTO != null)
            {
                Contato contato = new Contato
                {
                    Id = contatoDTO.Id,
                    IdCliente = contatoDTO.IdCliente,
                    Ddd = contatoDTO.Ddd,
                    Numero = contatoDTO.Numero,
                    Email = contatoDTO.Email,
                };

                return contato;
            }

            return null;
        }

        public ContatoDTO EntityToDTO(Contato contato)
        {
            if (contato != null)
            {
                ContatoDTO contatoDTO = new ContatoDTO
                {
                    Id = contato.Id,
                    IdCliente = contato.IdCliente,
                    Ddd = contato.Ddd,
                    Numero = contato.Numero,
                    Email = contato.Email
                };

                return contatoDTO;
            }

            return null;

        }

        public IEnumerable<ContatoDTO> ListEntityToListDTO(IEnumerable<Contato> contatos)
        {
            foreach (var contato in contatos)
            {
                ContatoDTO contatoDTO = new ContatoDTO
                {
                    Id = contato.Id,
                    IdCliente = contato.IdCliente,
                    Ddd = contato.Ddd,
                    Numero = contato.Numero,
                    Email = contato.Email
                };

                contatosDTO.Add(contatoDTO);
            }

            return contatosDTO;
        }
    }
}
