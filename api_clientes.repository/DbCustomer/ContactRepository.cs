using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using api_customer.domain.Entities;
using api_customer.repository.DbConsumer;
using System.Linq;

namespace api_customer.repository
{
    public class ContactRepository : CustomerRepositoryBase<Contact>, IContactRepository
    {
        #region Constructor
        private readonly CustomerContext _context;

        public ContactRepository(CustomerContext context) : base(context)
        {
            this._context = context;
        }
        #endregion

        #region Update
        public override void Update(Contact entity)
        {
            this.DetachedLocal(c => c.Id == entity.Id);

            base.Update(entity);
        }
        #endregion

        #region GetByIdCustomer
        public Contact GetByIdCustomer(int? idCustomer)
        {
            var query = from c in _context.Contacts
                           .Where(c => c.IdCustomer == idCustomer)
                           select c;

            return query.SingleOrDefault();
        } 
        #endregion
    }
}
