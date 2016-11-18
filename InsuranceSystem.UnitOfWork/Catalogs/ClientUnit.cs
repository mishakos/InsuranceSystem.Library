namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class ClientUnit : Disposable, IUnitOfWork<Client>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Client> clientRepository;

        public RepositoryBase<Client> Repository
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new RepositoryBase<Client>(context);
                return clientRepository;
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
