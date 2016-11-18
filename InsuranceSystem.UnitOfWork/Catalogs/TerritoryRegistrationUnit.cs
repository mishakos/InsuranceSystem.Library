namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class TerritoryRegistrationUnit : Disposable, IUnitOfWork<TerritoryRegistration>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<TerritoryRegistration> territoryRegistrationRepository;

        public RepositoryBase<TerritoryRegistration> Repository
        {
            get
            {
                if (territoryRegistrationRepository == null)
                    territoryRegistrationRepository = new RepositoryBase<TerritoryRegistration>(context);
                return territoryRegistrationRepository;
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
