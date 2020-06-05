using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.domain.Entities;
using api_customer.grpc.services.customer.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Map
{
    public class CustomerMapper : CustomerIMapper
    {
        List<CustomerDTO> customersDTOs = new List<CustomerDTO>();

        public Customer DTOToEntity(CustomerDTO customerDTO)
        {
            if (customerDTO != null)
            {
                Customer customer = new Customer
                {
                    Id = customerDTO.Id,
                    IdAddress = customerDTO.IdAddress,
                    Name = customerDTO.Name,
                    Surname = customerDTO.Surname,
                    Cpf = customerDTO.Cpf,
                    Genre = customerDTO.Genre
                };

                return customer;
            }

            return null;
        }

        public CustomerDTO EntityToDTO(Customer customer)
        {
            if (customer != null)
            {
                CustomerDTO customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    IdAddress = customer.IdAddress,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Cpf = customer.Cpf,
                    Genre = customer.Genre
                };

                return customerDTO;
            }

            return null;

        }

        public IEnumerable<CustomerDTO> ListEntityToListDTO(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                CustomerDTO customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    IdAddress = customer.IdAddress,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Cpf = customer.Cpf,
                    Genre = customer.Genre
                };

                customersDTOs.Add(customerDTO);
            }

            return customersDTOs;
        }

        public CustomerDTO ProtoToDTO(CustomerGet proto)
        {
            if (proto != null)
            {
                CustomerDTO customerDTO = new CustomerDTO
                {
                    Id = proto.Id,
                    IdAddress = proto.IdAddress,
                    Name = proto.Name,
                    Surname = proto.Surname,
                    Cpf = proto.Cpf,
                    Genre = proto.Genre.ToCharArray()[0]
                };

                return customerDTO;
            }

            return null;
        }

        public CustomerGet DTOToProto(CustomerDTO customerDTO)
        {
            if (customerDTO != null)
            {
                CustomerGet customer = new CustomerGet
                {
                    IdAddress = customerDTO.IdAddress.Value,
                    Name = customerDTO.Name,
                    Surname = customerDTO.Surname,
                    Cpf = customerDTO.Cpf,
                    Genre = customerDTO.Genre.ToString()
                };

                return customer;
            }

            return null;
        }

        public IEnumerable<CustomerDTO> ListProtoToListDTO(IEnumerable<CustomerGet> customers)
        {
            foreach (var customer in customers)
            {
                CustomerDTO customerDTO = new CustomerDTO
                {
                    Id = customer.Id,
                    IdAddress = customer.IdAddress,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Cpf = customer.Cpf,
                    Genre = customer.Genre.ToCharArray()[0]
                };

                customersDTOs.Add(customerDTO);
            }

            return customersDTOs;
        }
    }
}
