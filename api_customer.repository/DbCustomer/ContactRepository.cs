using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbCustomer;
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

        public override void Update(Contact entity)
        {
            this.DetachedLocal(c => c.Id == entity.Id);

            base.Update(entity);
        }

        public Contact GetByIdCustomer(int? idCustomer)
        {
            var query = from x in _context.Contacts
                           .Where(x => x.IdCustomer == idCustomer)
                           select x;

            return query.SingleOrDefault();
        } 
    }
}
