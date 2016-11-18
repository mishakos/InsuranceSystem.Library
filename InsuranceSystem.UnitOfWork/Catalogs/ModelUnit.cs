namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class ModelUnit : Disposable, IUnitOfWork<Model>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Model> modelRepository;

        public RepositoryBase<Model> Repository
        {
            get
            {
                if (modelRepository == null)
                    modelRepository = new RepositoryBase<Model>(context);
                return modelRepository;
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
