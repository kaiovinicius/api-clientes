using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbClientes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_customer.repository.DbConsumer
{
    public class CustomerRepositoryBase<TEntity> : IDbCustomerRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        #region Constructor
        private readonly CustomerContext context;

        public CustomerRepositoryBase(CustomerContext context)
        {
            this.context = context;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            context.Dispose();
        }
        #endregion

        #region List
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual List<TEntity> List()
        {
            var entities = from x in context.Set<TEntity>()
                        .OrderBy(x => (true))
                        select x;

            return entities.ToList();
        }
        #endregion

        #region Get
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual TEntity Get(int? id)
        {
            var entity = context.Set<TEntity>().Find(id);

            return entity;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Insert(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion

        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public virtual void Delete(int? id)
        {
            try
            {
                TEntity entity = Get(id);

                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region DetachedLocal
        public virtual void DetachedLocal(Func<TEntity, bool> entity)
        {
            var local = context.Set<TEntity>().Local.Where(entity).FirstOrDefault();

            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
        #endregion
    }
}
