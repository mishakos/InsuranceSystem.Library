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

    public class LVRegistrationService : ILocalityVehicleRegistrationService, IService<LocalityVehicleRegistrationDTO>
    {
        readonly IUnitOfWork<LocalityVehicleRegistration> lvrUnit;

        public LVRegistrationService()
        {
            lvrUnit = new LocalityVehicleRegistrationUnit();
        }

        public int Delete(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            lvrUnit.Dispose();
        }

        public IEnumerable<LocalityVehicleRegistrationDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<LocalityVehicleRegistrationDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public LocalityVehicleRegistrationDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LocalityVehicleRegistrationDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LocalityVehicleRegistrationDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(LocalityVehicleRegistrationDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
