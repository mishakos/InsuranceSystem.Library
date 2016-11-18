namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class LocalityVehicleRegistrationUnit : Disposable, 
        IUnitOfWork<LocalityVehicleRegistration>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<LocalityVehicleRegistration> localityVehicleRegistrationRepository;

        public RepositoryBase<LocalityVehicleRegistration> Repository
        {
            get
            {
                if (localityVehicleRegistrationRepository == null)
                    localityVehicleRegistrationRepository = 
                        new RepositoryBase<LocalityVehicleRegistration>(context);
                return localityVehicleRegistrationRepository;
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
