namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library.DataLayer;
    using Library.Infrastructure;
    using System.Threading.Tasks;

    public class AddressUnit : Disposable, IUnitOfWork<Address>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Address> addressRepository;

        public RepositoryBase<Address> Repository
        {
            get
            {
                if (addressRepository == null)
                    addressRepository = new RepositoryBase<Address>(context);
                return addressRepository;
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
