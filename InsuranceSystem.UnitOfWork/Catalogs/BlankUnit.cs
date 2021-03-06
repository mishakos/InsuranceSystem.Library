﻿namespace InsuranceSystem.UnitOfWork.Catalogs
{
    using Library.Models.Catalogs;
    using Library;
    using Library.DataLayer;
    using System;
    using Library.Infrastructure;
    using System.Threading.Tasks;
    public class BlankUnit : Disposable, IUnitOfWork<Blank>
    {
        InsuranceDbContext context = new InsuranceDbContext();
        RepositoryBase<Blank> blankRepository;

        public RepositoryBase<Blank> Repository
        {
            get
            {
                if (blankRepository == null)
                    blankRepository = new RepositoryBase<Blank>(context);
                return blankRepository;
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
