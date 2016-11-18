namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BankUnit : Disposable, IUnitOfWork<Bank>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Bank> bankRepository;

        public RepositoryBase<Bank> Repository
        {
            get
            {
                if (bankRepository == null)
                    bankRepository = new RepositoryBase<Bank>(context);
                return bankRepository;
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
