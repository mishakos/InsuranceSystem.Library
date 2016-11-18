using System.Collections.Generic;
using System.Data.Entity;
using InsuranceSystem.Library.DataLayer;
using InsuranceSystem.Library.Infrastructure;
using InsuranceSystem.Library.Models.Registries;
using InsuranceSystem.Library.Repositories.Interfaces;

namespace InsuranceSystem.Library.Repositories
{
    public class RegBlankMotionRepository : RepositoryBase<RegBlankMotion>,
        IRegistryRepository<RegBlankMotion>
    {
        private readonly InsuranceDbContext _dbContext;

        public RegBlankMotionRepository(DbContext dbContext) 
            : base(dbContext)
        {
            _dbContext = (_dbContext ?? (InsuranceDbContext)dbContext);
        }

        public void InsertRange(IEnumerable<RegBlankMotion> listTEntity)
        {
            _dbContext.RegBlankMotion.AddRange(listTEntity);
        }

        public void RemoveRange(IEnumerable<RegBlankMotion> listTEntity)
        {
            _dbContext.RegBlankMotion.RemoveRange(listTEntity);
        }
    }
}
