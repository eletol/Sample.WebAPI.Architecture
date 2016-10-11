using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace App.Services.Domain.BussinessMangers.Interfaces
{
    public interface IBaseBussinessManger<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        TEntity Save(TEntity item);
        TEntity Update(TEntity entityToUpdate);
        TEntity Delete(object id);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
    }
}
