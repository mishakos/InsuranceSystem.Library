namespace InsuranceSystem.UnitOfWork.Documents
{
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Models.Documents;
    using Library.Infrastructure;
    using System.Threading.Tasks;

    public class PostBlankUnit : Disposable, IUnitOfWork<PostBlank>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<PostBlank> postBlankRepository;

        public RepositoryBase<PostBlank> Repository
        {
            get
            {
                if (postBlankRepository == null)
                    postBlankRepository = new RepositoryBase<PostBlank>(context);
                return postBlankRepository;
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
