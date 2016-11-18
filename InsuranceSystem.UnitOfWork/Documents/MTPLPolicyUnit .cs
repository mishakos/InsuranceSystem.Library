namespace InsuranceSystem.UnitOfWork.Documents
{
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Models.Documents;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class MTPLPolicyUnit : Disposable, IUnitOfWork<MTPLPolicy>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<MTPLPolicy> mTPLPolicyRepository;

        public RepositoryBase<MTPLPolicy> Repository
        {
            get
            {
                if (mTPLPolicyRepository == null)
                    mTPLPolicyRepository = new RepositoryBase<MTPLPolicy>(context);
                return mTPLPolicyRepository;
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
