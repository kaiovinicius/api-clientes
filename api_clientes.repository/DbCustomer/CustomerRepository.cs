using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbClientes;
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

        #region Update
        public override void Update(Customer entity)
        {
            this.DetachedLocal(c => c.Id == entity.Id);

            base.Update(entity);
        } 
        #endregion
    }
}