using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceSystem.BLL.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        TEntity GetById(int? id);

        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int? id);
        Task<List<TEntity>> GetByNameAsync(string name);
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int? id);
        Task<int> DeleteAsync(TEntity entity);
        void Dispose();

    }
}
