namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class DriversNumberUnit : Disposable, IUnitOfWork<DriversNumber>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<DriversNumber> driversNumberRepository;

        public RepositoryBase<DriversNumber> Repository
        {
            get
            {
                if (driversNumberRepository == null)
                    driversNumberRepository = new RepositoryBase<DriversNumber>(context);
                return driversNumberRepository;
            }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }

        protected override void DisposeCore()
        {
            if (context != null)
                context.Dispose();
        }
    }
}
