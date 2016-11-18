namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class InsuranceTypeUnit : Disposable, IUnitOfWork<InsuranceType>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<InsuranceType> insuranceTypeRepository;

        public RepositoryBase<InsuranceType> Repository
        {
            get
            {
                if (insuranceTypeRepository == null)
                    insuranceTypeRepository = new RepositoryBase<InsuranceType>(context);
                return insuranceTypeRepository;
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
