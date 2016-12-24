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
    using System.Threading.Tasks;
    using UnitOfWork;

    public class SalesOfficeService : ISalesOfficeService
    {
        readonly IUnitOfWork<SalesOffice> soUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public SalesOfficeService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            soUnit = new SalesOfficeUnit();
        }

        public int Delete(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            soUnit.Dispose();
        }

        public IEnumerable<SalesOfficeDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesOfficeDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public SalesOfficeDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<SalesOfficeDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<SalesOfficeDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(SalesOfficeDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
