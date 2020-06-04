using api_customer.domain.Entities;

namespace api_customer.domain.core.Abstracts.Repositories.DbClientes
{
    public interface IContactRepository : IDbCustomerRepositoryBase<Contact>
    {
        #region GetByIdCustomer
        /// <summary>
        /// Get Contact by Customer Id
        /// </summary>
        /// <param name="idCustomer"></param>
        /// <returns></returns>
        Contact GetByIdCustomer(int? idCustomer); 
        #endregion
    }
}
