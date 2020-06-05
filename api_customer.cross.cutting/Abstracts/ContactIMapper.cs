using api_customer.application.DTO.Models;
using api_customer.domain.Entities;
using api_customer.grpc.services.contact.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Abstracts
{
    public interface ContactIMapper
    {
        Contact DTOToEntity(ContactDTO contatoDTO);
        ContactDTO EntityToDTO(Contact contato);
        IEnumerable<ContactDTO> ListEntityToListDTO(IEnumerable<Contact> contatos);
        IEnumerable<ContactDTO> ListProtoToListDTO(IEnumerable<ContactGet> contatos);
        ContactGet DTOToProto(ContactDTO contatoDTO);
        public ContactDTO ProtoToDTO(ContactGet proto);
    }
}
