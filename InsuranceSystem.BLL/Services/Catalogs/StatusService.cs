namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;
    using Interfaces;
    using UnitOfWork;
    using System.Threading.Tasks;

    public class StatusService : IStatusService, IService<StatusDTO>
    {
        readonly IUnitOfWork<Status> statusUnit;

        public StatusService()
        {
            statusUnit = new StatusUnit();
        }

        public int Delete(StatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(StatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            statusUnit.Dispose();
        }

        public IEnumerable<StatusDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public StatusDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<StatusDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StatusDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(StatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(StatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(StatusDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(StatusDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
