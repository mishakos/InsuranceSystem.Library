namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class FraudAttemptUnit : Disposable, IUnitOfWork<FraudAttempt>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<FraudAttempt> fraudAttemptRepository;

        public RepositoryBase<FraudAttempt> Repository
        {
            get
            {
                if (fraudAttemptRepository == null)
                    fraudAttemptRepository = new RepositoryBase<FraudAttempt>(context);
                return fraudAttemptRepository;
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
