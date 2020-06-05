using api_customer.data;
using api_customer.domain.core.Abstracts.Repositories.DbAddress;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api_customer.repository.DbEnderecos
{
    public class AddressRepositoryBase<TEntity> : IDbAddressRepositoryBase<TEntity>, IDisposable where TEntity : class
    {
        #region Constructor
        private readonly AddressContext context;

        public AddressRepositoryBase(AddressContext context)
        {
            this.context = context;
        }
        #endregion

        public void Dispose()
        {
            context.Dispose();
        }

        public virtual List<TEntity> List()
        {
            var entities = from x in context.Set<TEntity>()
                           .OrderBy(x => (true))
                           select x;

            return entities.ToList();
        }

        public virtual TEntity Get(int? id)
        {
            var entity = context.Set<TEntity>().Find(id);

            return entity;
        }

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

        public virtual void DetachedLocal(Func<TEntity, bool> entidade)
        {
            var local = context.Set<TEntity>().Local.Where(entidade).FirstOrDefault();

            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
        }
    }
}
