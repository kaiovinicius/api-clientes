using api_customer.domain.Entities;

namespace api_customer.domain.core.Abstracts.Repositories.DbCustomer
{
    public interface IContactRepository : IDbCustomerRepositoryBase<Contact>
    {
        Contact GetByIdCustomer(int? idCustomer); 
    }
}
