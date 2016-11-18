namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BrandUnit : Disposable, IUnitOfWork<Brand>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Brand> brandRepository;

        public RepositoryBase<Brand> Repository
        {
            get
            {
                if (brandRepository == null)
                    brandRepository = new RepositoryBase<Brand>(context);
                return brandRepository;
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
