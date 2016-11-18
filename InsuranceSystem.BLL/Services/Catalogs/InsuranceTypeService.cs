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

    public class InsuranceTypeService : IInsuranceTypeService, IService<InsuranceTypeDTO>
    {
        readonly IUnitOfWork<InsuranceType> itUnit;

        public InsuranceTypeService()
        {
            itUnit = new InsuranceTypeUnit();
        }

        public int Delete(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            itUnit.Dispose();
        }

        public IEnumerable<InsuranceTypeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<InsuranceTypeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public InsuranceTypeDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<InsuranceTypeDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InsuranceTypeDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(InsuranceTypeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
