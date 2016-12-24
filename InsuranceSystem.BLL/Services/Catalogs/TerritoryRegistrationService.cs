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
    using System.Threading.Tasks;
    using UnitOfWork;
    using InsuranceSystem.BLL.Infrastructure;

    public class TerritoryRegistrationService : ITerritoryRegistrationService
    {
        readonly IUnitOfWork<TerritoryRegistration> trUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public TerritoryRegistrationService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            trUnit = new TerritoryRegistrationUnit();
        }

        public int Delete(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            trUnit.Dispose();
        }

        public IEnumerable<TerritoryRegistrationDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<TerritoryRegistrationDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TerritoryRegistrationDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<TerritoryRegistrationDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TerritoryRegistrationDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TerritoryRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
