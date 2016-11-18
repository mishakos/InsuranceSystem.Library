namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class FirmUnit : Disposable, IUnitOfWork<Firm>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Firm> firmRepository;

        public RepositoryBase<Firm> Repository
        {
            get
            {
                if (firmRepository == null)
                    firmRepository = new RepositoryBase<Firm>(context);
                return firmRepository;
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
