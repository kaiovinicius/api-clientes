using System.Collections.Generic;

namespace api_customer.domain.Abstracts.Services
{
    public interface ICustomerServiceBase<TEntity> where TEntity : class
    {
        List<TEntity> List();

        TEntity Get(int? id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(int? id);
    }
}
