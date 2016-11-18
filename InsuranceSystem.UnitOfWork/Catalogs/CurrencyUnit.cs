namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class CurrencyUnit : Disposable, IUnitOfWork<Currency>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Currency> currencyRepository;

        public RepositoryBase<Currency> Repository
        {
            get
            {
                if (currencyRepository == null)
                    currencyRepository = new RepositoryBase<Currency>(context);
                return currencyRepository;
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
