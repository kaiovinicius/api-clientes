using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.domain.Entities;
using api_customer.grpc.services.address.Protos; 
using System.Collections.Generic;


namespace api_customer.cross.cutting.Map
{
    public class AddressMapper : AddressIMapper
    {
        List<AddressDTO> addressDTOs = new List<AddressDTO>();

        public Address DTOToEntity(AddressDTO addressDTOs)
        {
            if (addressDTOs != null)
            {
                Address address = new Address
                {
                    Id = addressDTOs.Id,
                    ZipCode = addressDTOs.ZipCode,
                    PublicArea = addressDTOs.PublicArea,
                    Neighborhood = addressDTOs.Neighborhood,
                    City = addressDTOs.City,
                    State = addressDTOs.State
                };

                return address;
            }

            return null;
        }

        public AddressDTO EntityToDTO(Address address)
        {
            if (address != null)
            {
                AddressDTO addressDTO = new AddressDTO
                {
                    Id = address.Id,
                    ZipCode = address.ZipCode,
                    PublicArea = address.PublicArea,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    State = address.State
                };

                return addressDTO;
            }

            return null;

        }

        public IEnumerable<AddressDTO> ListEntityToListDTO(IEnumerable<Address> addresses)
        {
            foreach (var address in addresses)
            {
                AddressDTO addressDTO = new AddressDTO
                {
                    Id = address.Id,
                    ZipCode = address.ZipCode,
                    PublicArea = address.PublicArea,
                    Neighborhood = address.Neighborhood,
                    City = address.City,
                    State = address.State
                };

                addressDTOs.Add(addressDTO);
            }

            return addressDTOs;
        }

        public AddressDTO ProtoToDTO(EnderecoGet proto)
        {
            if (proto != null)
            {
                AddressDTO addressDTO = new AddressDTO
                {
                    Id = proto.Id,
                    ZipCode = proto.Cep,
                    PublicArea = proto.Logradouro,
                    Neighborhood = proto.Logradouro,
                    City = proto.Cidade,
                    State = proto.Estado,
                };

                return addressDTO;
            }

            return null;
        }

        public EnderecoGet DTOToProto(AddressDTO addressDTO)
        {
            if (addressDTO != null)
            {
                EnderecoGet address = new EnderecoGet
                {
                    Cep = addressDTO.ZipCode,
                    Logradouro = addressDTO.PublicArea,
                    Bairro = addressDTO.PublicArea,
                    Cidade = addressDTO.City,
                    Estado = addressDTO.State,
                };

                return address;
            }

            return null;
        }

        public IEnumerable<AddressDTO> ListProtoToListDTO(IEnumerable<EnderecoGet> addresses)
        {
            foreach (var address in addresses)
            {
                AddressDTO addressDTO = new AddressDTO
                {
                    Id = address.Id,
                    ZipCode = address.Cep,
                    PublicArea = address.Logradouro,
                    Neighborhood = address.Logradouro,
                    City = address.Cidade,
                    State = address.Estado,
                };

                addressDTOs.Add(addressDTO);
            }

            return addressDTOs;
        }
    }
}
