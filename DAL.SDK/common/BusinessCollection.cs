using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.SDK.common
{
    public class BusinessCollection<TModel, TContext>
        where TModel : class, new()
        where TContext : DbContext

    {
        DbSet<TModel> dbSet;
        private TContext _context;
        public TContext ContextObject
        {
            get
            {
                return this._context;
            }
            set
            {
                this._context = value;
                this.dbSet = ContextObject.Set<TModel>();

            }
        }

        public BusinessCollection()
        {
       }

        public virtual IQueryable<TModel> Get(
           Expression<Func<TModel, bool>> filter = null,
           Func<IQueryable<TModel>, IOrderedQueryable<TModel>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TModel> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TModel GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public TModel Insert(TModel entity)
        {
            return dbSet.Add(entity);
        }

        public virtual TModel Delete(object id)
        {
            TModel entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual TModel Delete(TModel entityToDelete)
        {
            if (ContextObject.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
           return dbSet.Remove(entityToDelete);
        }

        public virtual TModel Update(TModel entityToUpdate)
        {
            var entity=dbSet.Attach(entityToUpdate);
            ContextObject.Entry(entityToUpdate).State = EntityState.Modified;
            return entity;
        }


    }
}
