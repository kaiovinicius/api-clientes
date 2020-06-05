using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.grpc.services.contact.Protos;
using System.Collections.Generic;

namespace api_customer.application.Concrets
{
    public class ContactApplicationService : IContactApplicationService
    {
        #region Variables
        private readonly ContactIMapper _mapperContact;
        private readonly ContactService.ContactServiceClient _serviceGrpcContact;
        #endregion

        #region Constructor
        public ContactApplicationService(ContactService.ContactServiceClient serviceGrpcContact, ContactIMapper mapperContact)
        {
            this._serviceGrpcContact = serviceGrpcContact;
            this._mapperContact = mapperContact;
        }
        #endregion

        public IEnumerable<ContactDTO> List()
        {
            var contacts = _serviceGrpcContact.List(new EmptyContact { }).Items;

            return _mapperContact.ListProtoToListDTO(contacts);
        }

        public ContactDTO Get(int? id)
        {
            var contact = _serviceGrpcContact.Get(new RequestContact { Id = id.Value});

            return _mapperContact.ProtoToDTO(contact);
        }

        public void Insert(ContactDTO contactDTO)
        {
            var proto = _mapperContact.DTOToProto(contactDTO);

            var contact = new ContactPost
            {
                IdCustomer = proto.IdCustomer,
                Ddd = proto.Ddd,
                Number = proto.Number,
                Email = proto.Email
            };

            _serviceGrpcContact.Insert(contact);
        }

        public void Update(ContactDTO contactDTO)
        {
            var proto = _mapperContact.DTOToProto(contactDTO);

            var contact = new ContactPut
            {
                Id = contactDTO.Id.Value,
                IdCustomer = proto.IdCustomer,
                Ddd = proto.Ddd,
                Number = proto.Number,
                Email = proto.Email
            };

            _serviceGrpcContact.Update(contact);
        }

        public void Delete(int? id)
        {
            _serviceGrpcContact.Delete(new RequestContact { Id = id.Value });
        }
    }
}
