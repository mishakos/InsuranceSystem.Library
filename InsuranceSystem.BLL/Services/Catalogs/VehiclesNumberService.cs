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

    public class VehiclesNumberService : IVehiclesNumberService, IService<VehiclesNumberDTO>
    {
        readonly IUnitOfWork<VehiclesNumber> vnUnit;

        public VehiclesNumberService()
        {
            vnUnit = new VehiclesNumberUnit();
        }

        public int Delete(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            vnUnit.Dispose();
        }

        public IEnumerable<VehiclesNumberDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<VehiclesNumberDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public VehiclesNumberDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<VehiclesNumberDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehiclesNumberDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(VehiclesNumberDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
