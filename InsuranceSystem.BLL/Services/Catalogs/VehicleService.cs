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

    public class VehicleService : IVehicleService
    {
        readonly IUnitOfWork<Vehicle> vehicleUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public VehicleService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            vehicleUnit = new VehicleUnit();
        }

        public int Delete(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            vehicleUnit.Dispose();
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public VehicleDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
