using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.Entities;
using api_clientes.grpc.services.cliente.Protos;
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

        public ContatoDTO ProtoToDTO(ContatoGet proto)
        {
            if (proto != null)
            {
                ContatoDTO contatoDTO = new ContatoDTO
                {
                    Id = proto.Id,
                    IdCliente = proto.IdCliente,
                    Ddd = proto.Ddd,
                    Numero = proto.Numero,
                    Email = proto.Email
                };

                return contatoDTO;
            }

            return null;
        }

        public ContatoGet DTOToProto(ContatoDTO contatoDTO)
        {
            if (contatoDTO != null)
            {
                ContatoGet contato = new ContatoGet
                {
                    IdCliente = contatoDTO.IdCliente,
                    Ddd = contatoDTO.Ddd,
                    Numero= contatoDTO.Numero,
                    Email= contatoDTO.Email
                };

                return contato;
            }

            return null;
        }

        public IEnumerable<ContatoDTO> ListProtoToListDTO(IEnumerable<ContatoGet> contatos)
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
