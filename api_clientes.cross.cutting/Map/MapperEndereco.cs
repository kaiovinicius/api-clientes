using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.Entities;
using api_clientes.grpc.services.endereco.Protos;
using System.Collections.Generic;


namespace api_clientes.cross.cutting.Map
{
    public class MapperEndereco : IMapperEndereco
    {
        List<EnderecoDTO> enderecoDTOs = new List<EnderecoDTO>();

        public Endereco DTOToEntity(EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO != null)
            {
                Endereco endereco = new Endereco
                {
                    Id = enderecoDTO.Id,
                    Cep = enderecoDTO.Cep,
                    Logradouro = enderecoDTO.Logradouro,
                    Bairro = enderecoDTO.Bairro,
                    Cidade = enderecoDTO.Cidade,
                    Estado = enderecoDTO.Estado
                };

                return endereco;
            }

            return null;
        }

        public EnderecoDTO EntityToDTO(Endereco endereco)
        {
            if (endereco != null)
            {
                EnderecoDTO enderecoDTO = new EnderecoDTO
                {
                    Id = endereco.Id,
                    Cep = endereco.Cep,
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado
                };

                return enderecoDTO;
            }

            return null;

        }

        public IEnumerable<EnderecoDTO> ListEntityToListDTO(IEnumerable<Endereco> enderecos)
        {
            foreach (var endereco in enderecos)
            {
                EnderecoDTO enderecoDTO = new EnderecoDTO
                {
                    Id = endereco.Id,
                    Cep = endereco.Cep,
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Bairro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado
                };

                enderecoDTOs.Add(enderecoDTO);
            }

            return enderecoDTOs;
        }

        public EnderecoDTO ProtoToDTO(EnderecoGet proto)
        {
            if (proto != null)
            {
                EnderecoDTO enderecoDTO = new EnderecoDTO
                {
                    Id = proto.Id,
                    Cep = proto.Cep,
                    Logradouro = proto.Logradouro,
                    Bairro = proto.Logradouro,
                    Cidade = proto.Cidade,
                    Estado = proto.Estado,
                };

                return enderecoDTO;
            }

            return null;
        }

        public EnderecoGet DTOToProto(EnderecoDTO enderecoDTO)
        {
            if (enderecoDTO != null)
            {
                EnderecoGet contato = new EnderecoGet
                {
                    Cep = enderecoDTO.Cep,
                    Logradouro = enderecoDTO.Logradouro,
                    Bairro = enderecoDTO.Logradouro,
                    Cidade = enderecoDTO.Cidade,
                    Estado = enderecoDTO.Estado,
                };

                return contato;
            }

            return null;
        }

        public IEnumerable<EnderecoDTO> ListProtoToListDTO(IEnumerable<EnderecoGet> enderecos)
        {
            foreach (var endereco in enderecos)
            {
                EnderecoDTO enderecoDTO = new EnderecoDTO
                {
                    Id = endereco.Id,
                    Cep = endereco.Cep,
                    Logradouro = endereco.Logradouro,
                    Bairro = endereco.Logradouro,
                    Cidade = endereco.Cidade,
                    Estado = endereco.Estado,
                };

                enderecoDTOs.Add(enderecoDTO);
            }

            return enderecoDTOs;
        }
    }
}
