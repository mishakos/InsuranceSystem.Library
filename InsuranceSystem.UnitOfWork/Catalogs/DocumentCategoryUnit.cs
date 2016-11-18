namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class DocumentCategoryUnit : Disposable, IUnitOfWork<DocumentCategory>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<DocumentCategory> documentCategoryRepository;

        public RepositoryBase<DocumentCategory> Repository
        {
            get
            {
                if (documentCategoryRepository == null)
                    documentCategoryRepository = new RepositoryBase<DocumentCategory>(context);
                return documentCategoryRepository;
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
