using api_customer.domain.Abstracts.Services;
using api_customer.domain.core.Abstracts.Repositories.DbCustomer;
using System.Collections.Generic;

namespace api_customer.domain.Services
{
    public class CustomerServiceBase<TEntity> : ICustomerServiceBase<TEntity> where TEntity : class
    {
        #region Constructor
        private readonly IDbCustomerRepositoryBase<TEntity> repositoryBase;

        public CustomerServiceBase(IDbCustomerRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        #endregion

        public virtual List<TEntity> List()
        {
            return repositoryBase.List();
        }

        public virtual TEntity Get(int? id)
        {
            return repositoryBase.Get(id);
        }

        public virtual void Insert(TEntity entidade)
        {
            repositoryBase.Insert(entidade);
        }

        public virtual void Update(TEntity entidade)
        {
            repositoryBase.Update(entidade);
        }

        public virtual void Delete(int? id)
        {
            repositoryBase.Delete(id);
        }
    }
}