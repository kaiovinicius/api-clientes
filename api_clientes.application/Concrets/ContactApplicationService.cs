using api_customer.application.Abstracts;
using api_customer.application.DTO.Models;
using api_customer.cross.cutting.Abstracts;
using api_customer.domain.core.Abstracts.Services;
using api_customer.grpc.services.customer.Protos;
using System.Collections.Generic;

namespace api_customer.application.Concrets
{
    public class ContactApplicationService : IContactApplicationService
    {
        #region Variables
        private readonly ContactIMapper _mapperContact;
        private readonly ContatoService.ContatoServiceClient _serviceGrpcContact;
        #endregion

        #region Constructor
        public ContactApplicationService(ContatoService.ContatoServiceClient serviceGrpcContact, ContactIMapper mapperContact)
        {
            this._serviceGrpcContact = serviceGrpcContact;
            this._mapperContact = mapperContact;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ContactDTO> List()
        {
            var contacts = _serviceGrpcContact.Listar(new EmptyContato { }).Items;

            return _mapperContact.ListProtoToListDTO(contacts);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactDTO Get(int? id)
        {
            var contact = _serviceGrpcContact.Obter(new RequestContato { Id = id.Value});

            return _mapperContact.ProtoToDTO(contact);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contactDTO"></param>
        public void Insert(ContactDTO contactDTO)
        {
            var proto = _mapperContact.DTOToProto(contactDTO);

            var contact = new ContatoPost
            {
                IdCliente = proto.IdCliente,
                Ddd = proto.Ddd,
                Numero = proto.Numero,
                Email = proto.Email
            };

            _serviceGrpcContact.Inserir(contact);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="contactDTO"></param>
        public void Update(ContactDTO contactDTO)
        {
            var proto = _mapperContact.DTOToProto(contactDTO);

            var contact = new ContatoPut
            {
                Id = contactDTO.Id.Value,
                IdCliente = proto.IdCliente,
                Ddd = proto.Ddd,
                Numero = proto.Numero,
                Email = proto.Email
            };

            _serviceGrpcContact.Alterar(contact);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int? id)
        {
            _serviceGrpcContact.Excluir(new RequestContato { Id = id.Value });
        }
        #endregion
    }
}
