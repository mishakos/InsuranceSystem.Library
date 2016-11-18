namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class DepartmentUnit : Disposable, IUnitOfWork<Department>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Department> departmentRepository;

        public RepositoryBase<Department> Repository
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new RepositoryBase<Department>(context);
                return departmentRepository;
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
