namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class PersonUnit : Disposable, IUnitOfWork<Person>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Person> personRepository;

        public RepositoryBase<Person> Repository
        {
            get
            {
                if (personRepository == null)
                    personRepository = new RepositoryBase<Person>(context);
                return personRepository;
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
