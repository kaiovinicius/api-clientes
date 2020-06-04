using api_customer.domain.Abstracts.Services;
using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using System.Collections.Generic;

namespace api_customer.domain.Services
{
    public class CustomerServiceBase<TEntity> : IServiceBaseCustomer<TEntity> where TEntity : class
    {
        #region Construtor
        private readonly IDbCustomerRepositoryBase<TEntity> repositoryBase;

        public CustomerServiceBase(IDbCustomerRepositoryBase<TEntity> repositoryBase)
        {
            this.repositoryBase = repositoryBase;
        }
        #endregion

        #region Listar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> List()
        {
            return repositoryBase.List();
        }
        #endregion

        #region Obter
        /// <summary>
        /// Obter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(int? id)
        {
            return repositoryBase.Get(id);
        }
        #endregion

        #region Inserir
        /// <summary>
        /// Inserir
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Insert(TEntity entidade)
        {
            repositoryBase.Insert(entidade);
        }
        #endregion

        #region Alterar
        /// <summary>
        /// Alterar
        /// </summary>
        /// <param name="entidade"></param>
        public virtual void Update(TEntity entidade)
        {
            repositoryBase.Update(entidade);
        }
        #endregion

        #region Excluir
        /// <summary>
        /// Excluir
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int? id)
        {
            repositoryBase.Delete(id);
        }
        #endregion
    }
}