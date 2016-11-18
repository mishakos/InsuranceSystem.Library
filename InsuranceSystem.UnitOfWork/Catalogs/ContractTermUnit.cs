namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class ContractTermUnit : Disposable, IUnitOfWork<ContractTerm>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<ContractTerm> contractTermRepository;

        public RepositoryBase<ContractTerm> Repository
        {
            get
            {
                if (contractTermRepository == null)
                    contractTermRepository = new RepositoryBase<ContractTerm>(context);
                return contractTermRepository;
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
