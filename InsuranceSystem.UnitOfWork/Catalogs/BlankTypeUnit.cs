namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BlankTypeUnit : Disposable, IUnitOfWork<BlankType>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<BlankType> blankTypeRepository;

        public RepositoryBase<BlankType> Repository
        {
            get
            {
                if (blankTypeRepository == null)
                    blankTypeRepository = new RepositoryBase<BlankType>(context);
                return blankTypeRepository;
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
