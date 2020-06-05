using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.domain.Entities;
using api_customer.grpc.services.contact.Protos;
using System.Collections.Generic;

namespace api_customer.cross.cutting.Map
{
    public class ContactMapper : ContactIMapper
    {
        List<ContactDTO> contactsDTO = new List<ContactDTO>();

        public Contact DTOToEntity(ContactDTO contactDTO)
        {
            if (contactDTO != null)
            {
                Contact contact = new Contact
                {
                    Id = contactDTO.Id,
                    IdCustomer = contactDTO.IdCustomer,
                    Ddd = contactDTO.Ddd,
                    Number = contactDTO.Number,
                    Email = contactDTO.Email,
                };

                return contact;
            }

            return null;
        }

        public ContactDTO EntityToDTO(Contact contact)
        {
            if (contact != null)
            {
                ContactDTO contactDTO = new ContactDTO
                {
                    Id = contact.Id,
                    IdCustomer = contact.IdCustomer,
                    Ddd = contact.Ddd,
                    Number = contact.Number,
                    Email = contact.Email
                };

                return contactDTO;
            }

            return null;

        }

        public IEnumerable<ContactDTO> ListEntityToListDTO(IEnumerable<Contact> contacts)
        {
            foreach (var contact in contacts)
            {
                ContactDTO contactDTO = new ContactDTO
                {
                    Id = contact.Id,
                    IdCustomer = contact.IdCustomer,
                    Ddd = contact.Ddd,
                    Number = contact.Number,
                    Email = contact.Email
                };

                contactsDTO.Add(contactDTO);
            }

            return contactsDTO;
        }

        public ContactDTO ProtoToDTO(ContactGet proto)
        {
            if (proto != null)
            {
                ContactDTO contactDTO = new ContactDTO
                {
                    Id = proto.Id,
                    IdCustomer = proto.IdCustomer,
                    Ddd = proto.Ddd,
                    Number = proto.Number,
                    Email = proto.Email
                };

                return contactDTO;
            }

            return null;
        }

        public ContactGet DTOToProto(ContactDTO contactDTO)
        {
            if (contactDTO != null)
            {
                ContactGet contact = new ContactGet
                {
                    IdCustomer = contactDTO.IdCustomer,
                    Ddd = contactDTO.Ddd,
                    Number = contactDTO.Number,
                    Email= contactDTO.Email
                };

                return contact;
            }

            return null;
        }

        public IEnumerable<ContactDTO> ListProtoToListDTO(IEnumerable<ContactGet> contacts)
        {
            foreach (var contact in contacts)
            {
                ContactDTO contactDTO = new ContactDTO
                {
                    Id = contact.Id,
                    IdCustomer = contact.IdCustomer,
                    Ddd = contact.Ddd,
                    Number = contact.Number,
                    Email = contact.Email
                };

                contactsDTO.Add(contactDTO);
            }

            return contactsDTO;
        }
    }
}
