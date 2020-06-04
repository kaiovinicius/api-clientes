using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbEnderecos;
using api_customer.domain.Entities;
using api_customer.repository.DbEnderecos;

namespace api_customer.repository
{
    public class AddressRepository : AddressRepositoryBase<Address>, IAdressRepository
    {
        #region Constructor
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context) : base(context)
        {
            this._context = context;
        }
        #endregion

        #region Update
        public override void Update(Address entity)
        {
            this.DetachedLocal(c => c.Id == entity.Id);

            base.Update(entity);
        } 
        #endregion
    }
}
