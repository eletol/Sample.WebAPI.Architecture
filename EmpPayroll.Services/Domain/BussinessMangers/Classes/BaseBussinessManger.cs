using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.DynamicData;
using App.Services.Domain.BussinessMangers.Interfaces;
using App.Services.Domain.Repository;
using App.Services.Domain.UnitOfWork;

namespace App.Services.Domain.BussinessMangers.Classes
{
    public class BaseBussinessManger<TEntity, TRepository> : IBaseBussinessManger<TEntity> where TEntity : class
        where TRepository : IBaseRepository<TEntity>
    {
        protected IBaseRepository<TEntity> Repository { get; set; }
        protected IUnitOfWork UnitOfWork { get; set; }
        public BaseBussinessManger(IUnitOfWork _uow)
        {
            if (_uow == null)
            {
                throw new ArgumentNullException("no repository provided");
            }
            UnitOfWork = _uow;
            Repository = UnitOfWork.Repository<TEntity, TRepository>();
        }

      

        public virtual TEntity GetById(object id)
        {
            return Repository.GetById(id);
        }

        public virtual TEntity Save(TEntity item)
        {
           var addedItem= Repository.Save(item);
            UnitOfWork.Save();
            return addedItem;
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            var editedItem = Repository.Update(entityToUpdate);
            UnitOfWork.Save();
            return editedItem;
        }

        public virtual TEntity Delete(object id)
        {
            var deletedItem= Repository.Delete(id);
            UnitOfWork.Save();
            return deletedItem;
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return Repository.Get(filter, orderBy, includeProperties);
        }
    }

}