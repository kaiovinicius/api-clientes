using System.Collections.Generic;

namespace api_customer.domain.Abstracts.Services
{
    public interface IServiceBaseCustomer<TEntity> where TEntity : class
    {
        #region List
        List<TEntity> List();
        #endregion

        #region Get
        TEntity Get(int? id);
        #endregion

        #region Insert
        void Insert(TEntity entity);
        #endregion

        #region Update
        void Update(TEntity entity);
        #endregion

        #region Delete
        void Delete(int? id);
        #endregion
    }
}
