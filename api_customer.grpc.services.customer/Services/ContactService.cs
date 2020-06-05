using api_customer.domain.core.Abstracts.Repositories.DbCustomer;
using api_customer.domain.Entities;
using api_customer.grpc.services.contact.Protos;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using static api_customer.grpc.services.contact.Protos.ContactService;

namespace api_customer.grpc.services.customer.Services
{
    public class ContactService : ContactServiceBase
    {
        #region Constructor
        private readonly IContactRepository _repositoryContato;

        public ContactService(IContactRepository repositoryContato)
        {
            this._repositoryContato = repositoryContato;
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ContactsGet> List(Empty request, ServerCallContext context)
        {
            ContactsGet protos = new ContactsGet();

            var contacts = _repositoryContato.List().ToList();

            foreach (var contact in contacts)
            {
                var proto = new ContactGet
                {
                    Id = contact.Id.Value,
                    IdCustomer = contact.IdCustomer,
                    Ddd = contact.Ddd,
                    Number = contact.Number,
                    Email = contact.Email
                };

                protos.Items.Add(proto);
            }

            return Task.FromResult(protos);
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<ContactGet> Get(Request request, ServerCallContext context)
        {
            var contact = _repositoryContato.Get(request.Id);

            return Task.FromResult(new ContactGet
            {
                Id = contact.Id.Value,
                IdCustomer = contact.IdCustomer,
                Ddd = contact.Ddd,
                Number = contact.Number,
                Email = contact.Email
            });
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Insert(ContactPost request, ServerCallContext context)
        {
            var contato = new Contact
            {
                IdCustomer = request.IdCustomer,
                Ddd = request.Ddd,
                Number = request.Number,
                Email = request.Email
            };

            _repositoryContato.Insert(contato);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Update(ContactPut request, ServerCallContext context)
        {
            var contato = new Contact
            {
                Id = request.Id,
                IdCustomer = request.IdCustomer,
                Ddd = request.Ddd,
                Number = request.Number,
                Email = request.Email
            };

            if (_repositoryContato.Get(contato.Id) == null)
            {
                throw new ApplicationException("Contact not found.");
            }

            _repositoryContato.Update(contato);

            return Task.FromResult(new Empty());
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task<Empty> Delete(Request request, ServerCallContext context)
        {
            if (_repositoryContato.Get(request.Id) == null)
            {
                throw new ApplicationException("Contact not found.");
            }

            _repositoryContato.Delete(request.Id);

            return Task.FromResult(new Empty());
        }
        #endregion
    }
}
