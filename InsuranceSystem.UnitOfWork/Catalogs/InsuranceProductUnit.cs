namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class InsuranceProductUnit : Disposable, IUnitOfWork<InsuranceProduct>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<InsuranceProduct> insuranceProductRepository;

        public RepositoryBase<InsuranceProduct> Repository
        {
            get
            {
                if (insuranceProductRepository == null)
                    insuranceProductRepository = new RepositoryBase<InsuranceProduct>(context);
                return insuranceProductRepository;
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
