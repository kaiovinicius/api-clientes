using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbCustomer;
using api_customer.domain.Entities;
using api_customer.repository.DbConsumer;

namespace api_customer.repository
{
    public class CustomerRepository : CustomerRepositoryBase<Customer>, ICustomerRepository
    {
        #region Constructor
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context) : base(context)
        {
            _context = context;
        }
        #endregion

        public override void Update(Customer entity)
        {
            this.DetachedLocal(x => x.Id == entity.Id);

            base.Update(entity);
        } 
    }
}