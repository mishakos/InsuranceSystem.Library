﻿namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class SalesOfficeUnit : Disposable, IUnitOfWork<SalesOffice>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<SalesOffice> salesOfficeRepository;

        public RepositoryBase<SalesOffice> Repository
        {
            get
            {
                if (salesOfficeRepository == null)
                    salesOfficeRepository = new RepositoryBase<SalesOffice>(context);
                return salesOfficeRepository;
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
