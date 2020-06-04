using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.domain.core.Abstracts.Services;
using api_customer.domain.Entities;
using System;

namespace api_customer.domain.Services
{
    public class CustomerService : CustomerServiceBase<Customer>, ICustomerService
    {
        #region Constructor
        private readonly ICustomerRepository _repositoryCustomer;
        private readonly IContactRepository _repositoryContact;

        public CustomerService(ICustomerRepository repositoryCustomer,
                              IContactRepository repositoryContact) : base(repositoryCustomer)
        {
            this._repositoryCustomer = repositoryCustomer;
            this._repositoryContact = repositoryContact;
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public override void Update(Customer customer)
        {
            if (_repositoryCustomer.Get(customer.Id) == null)
            {
                throw new ApplicationException("Contact not found.");
            }

            _repositoryCustomer.Update(customer);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public override void Delete(int? id)
        {
            var contact = _repositoryContact.GetByIdCustomer(id);

            if (contact != null)
            {
                _repositoryContact.Delete(contact.Id);
            }

            _repositoryCustomer.Delete(id);
        }
        #endregion
    }
}