namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class VehiclesNumberUnit : Disposable, IUnitOfWork<VehiclesNumber>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<VehiclesNumber> vehiclesNumberRepository;

        public RepositoryBase<VehiclesNumber> Repository
        {
            get
            {
                if (vehiclesNumberRepository == null)
                    vehiclesNumberRepository = new RepositoryBase<VehiclesNumber>(context);
                return vehiclesNumberRepository;
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
