using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.domain.core.Abstracts.Services;
using api_customer.domain.Entities;
using System;

namespace api_customer.domain.Services
{
    public class ContactService : CustomerServiceBase<Contact>, IContactService
    {
        #region Constructor
        private readonly IContactRepository _repositoryContact;

        public ContactService(IContactRepository _repositoryContact) : base(_repositoryContact)
        {
            this._repositoryContact = _repositoryContact;
        }
        #endregion

        #region Alterar
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        public override void Update(Contact contact)
        {
            if (_repositoryContact.Get(contact.Id) == null)
            {
                throw new ApplicationException("Contact not found.");
            }

            _repositoryContact.Update(contact);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(int? id)
        {
            if (_repositoryContact.Get(id) == null)
            {
                throw new ApplicationException("Contact not found.");
            }

            _repositoryContact.Delete(id);
        }
        #endregion
    }
}