using System.Collections.Generic;
using InsuranceSystem.Library.Infrastructure;


namespace InsuranceSystem.Library.Repositories.Interfaces
{
    public interface IRegistryRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        void InsertRange(IEnumerable<TEntity> listTEntity);
        void RemoveRange(IEnumerable<TEntity> listTEntity);
    }
}
