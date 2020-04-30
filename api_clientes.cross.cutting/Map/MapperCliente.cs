using api_clientes.application.DTO.Models;
using api_clientes.cross.cutting.Abstracts;
using api_clientes.domain.Entities;
using System.Collections.Generic;

namespace api_clientes.cross.cutting.Map
{
    public class MapperCliente : IMapperCliente
    {
        List<ClienteDTO> clienteDTOs = new List<ClienteDTO>();

        public Cliente DTOToEntity(ClienteDTO clienteDTO)
        {
            if (clienteDTO != null)
            {
                Cliente cliente = new Cliente
                {
                    Id = clienteDTO.Id,
                    IdEndereco = clienteDTO.IdEndereco,
                    Nome = clienteDTO.Nome,
                    Sobrenome = clienteDTO.Sobrenome,
                    Cpf = clienteDTO.Cpf,
                    Sexo = clienteDTO.Sexo
                };

                return cliente;
            }

            return null;
        }

        public ClienteDTO EntityToDTO(Cliente cliente)
        {
            if (cliente != null)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Id = cliente.Id,
                    IdEndereco = cliente.IdEndereco,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Cpf = cliente.Cpf,
                    Sexo = cliente.Sexo
                };

                return clienteDTO;
            }

            return null;

        }

        public IEnumerable<ClienteDTO> ListEntityToListDTO(IEnumerable<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                ClienteDTO clienteDTO = new ClienteDTO
                {
                    Id = cliente.Id,
                    IdEndereco = cliente.IdEndereco,
                    Nome = cliente.Nome,
                    Sobrenome = cliente.Sobrenome,
                    Cpf = cliente.Cpf,
                    Sexo = cliente.Sexo
                };

                clienteDTOs.Add(clienteDTO);
            }

            return clienteDTOs;
        }
    }
}
