namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BonusMalusUnit : Disposable, IUnitOfWork<BonusMalus>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<BonusMalus> bonusMalusRepository;

        public RepositoryBase<BonusMalus> Repository
        {
            get
            {
                if (bonusMalusRepository == null)
                    bonusMalusRepository = new RepositoryBase<BonusMalus>(context);
                return bonusMalusRepository;
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
