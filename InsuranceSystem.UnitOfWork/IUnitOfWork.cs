using System;
using System.Threading.Tasks;
using InsuranceSystem.Library.Infrastructure;

namespace InsuranceSystem.UnitOfWork
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : class
    {
        RepositoryBase<TEntity> Repository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
