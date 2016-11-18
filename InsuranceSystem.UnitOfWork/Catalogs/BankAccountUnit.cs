namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BankAccountUnit : Disposable, IUnitOfWork<BankAccount>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<BankAccount> bankAccountRepository;

        public RepositoryBase<BankAccount> Repository
        {
            get
            {
                if (bankAccountRepository == null)
                    bankAccountRepository = new RepositoryBase<BankAccount>(context);
                return bankAccountRepository;
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
