using App.Services.Domain.Repository;

namespace App.Services.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        void Dispose(bool disposing);

         TRepository Repository<TEntity, TRepository>() where TEntity : class
            where TRepository : IBaseRepository<TEntity>;
    }
}
