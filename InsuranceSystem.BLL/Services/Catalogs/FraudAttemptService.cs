namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;
    using Interfaces;
    using UnitOfWork;
    using System.Threading.Tasks;

    public class FraudAttemptService : IFraudAttemptService, IService<FraudAttemptDTO>
    {
        readonly IUnitOfWork<FraudAttempt> faUnit;

        public FraudAttemptService()
        {
            faUnit = new FraudAttemptUnit();
        }

        public int Delete(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            faUnit.Dispose();
        }

        public IEnumerable<FraudAttemptDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<FraudAttemptDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public FraudAttemptDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<FraudAttemptDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FraudAttemptDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(FraudAttemptDTO entity)
        {
            throw new NotImplementedException();
        }
    
    }
}
