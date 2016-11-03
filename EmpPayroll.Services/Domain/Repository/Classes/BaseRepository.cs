using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Services.Domain.DBContext;
using DAL.SDK.common;

namespace App.Services.Domain.Repository
{
    public class BaseRepository<TCollection, TItem> :IBaseRepository<TItem>
        where TCollection : BusinessCollection<TItem, DbContext> , new()
        where TItem : class,new()


    {
        public TCollection Collection { get; set; }
        public BaseRepository(DbContext context)
        {
            Collection = new TCollection {ContextObject = context};

        }

        public virtual TItem GetById(object id)
        {
            return Collection.GetByID(id);
        }

        public virtual TItem Save(TItem item)
        {
            return Collection.Insert(item);
        }

        public virtual TItem Update(TItem entityToUpdate)
        {
            var c = new TCollection();
            return c.Update(entityToUpdate);
        }

        public virtual TItem Delete(object id)
        {
            return Collection.Delete(id); ;
        }

        public virtual IQueryable<TItem> Get(Expression<Func<TItem, bool>> filter = null, Func<IQueryable<TItem>, IOrderedQueryable<TItem>> orderBy = null, string includeProperties = "")
        {
            return Collection.Get(filter, orderBy, includeProperties); 
        }
    }
}