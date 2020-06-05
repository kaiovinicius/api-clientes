using api_customer.domain.Abstracts.Services;
using api_customer.domain.core.Abstracts.Repositories.DbAddress;
using System.Collections.Generic;

namespace api_customer.domain.Services
{
    public class AddressServiceBase<TEntity> : IAddressServiceBase<TEntity> where TEntity : class
    {
        #region Constructor
        private readonly IDbAddressRepositoryBase<TEntity> repositoryBase;

        public AddressServiceBase(IDbAddressRepositoryBase<TEntity> repositoryBase)
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