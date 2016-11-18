namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class StatusUnit : Disposable, IUnitOfWork<Status>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Status> statusRepository;

        public RepositoryBase<Status> Repository
        {
            get
            {
                if (statusRepository == null)
                    statusRepository = new RepositoryBase<Status>(context);
                return statusRepository;
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
