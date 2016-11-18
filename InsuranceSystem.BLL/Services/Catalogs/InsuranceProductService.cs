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

    public class InsuranceProductService : IInsuranceProductService, IService<InsuranceProductDTO>
    {
        readonly IUnitOfWork<InsuranceProduct> ipUnit;

        public InsuranceProductService()
        {
            ipUnit = new InsuranceProductUnit();
        }

        public int Delete(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            ipUnit.Dispose();
        }

        public IEnumerable<InsuranceProductDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<InsuranceProductDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public InsuranceProductDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceProductDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InsuranceProductDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(InsuranceProductDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
