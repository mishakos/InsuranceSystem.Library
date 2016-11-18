namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library.DataLayer;
    using Library.Infrastructure;
    using System.Threading.Tasks;

    public class AreasOfUseUnit : Disposable, IUnitOfWork<AreaOfUse>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<AreaOfUse> areasOfUseRepository;

        public RepositoryBase<AreaOfUse> Repository
        {
            get
            {
                if (areasOfUseRepository == null)
                    areasOfUseRepository = new RepositoryBase<AreaOfUse>(context);
                return areasOfUseRepository;
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
