namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class VehicleUnit : Disposable, IUnitOfWork<Vehicle>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Vehicle> vehicleRepository;

        public RepositoryBase<Vehicle> Repository
        {
            get
            {
                if (vehicleRepository == null)
                    vehicleRepository = new RepositoryBase<Vehicle>(context);
                return vehicleRepository;
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
