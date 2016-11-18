namespace InsuranceSystem.UnitOfWork.Documents
{
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Models.Documents;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class MoveBlankUnit : Disposable, IUnitOfWork<MoveBlank>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<MoveBlank> moveBlankRepository;

        public RepositoryBase<MoveBlank> Repository
        {
            get
            {
                if (moveBlankRepository == null)
                    moveBlankRepository = new RepositoryBase<MoveBlank>(context);
                return moveBlankRepository;
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
