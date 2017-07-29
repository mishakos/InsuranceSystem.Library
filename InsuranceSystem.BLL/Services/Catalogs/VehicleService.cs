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
            CheckForNull(entity);
            vehicleUnit.Repository.Delete(entity.Id);
            return vehicleUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            vehicleUnit.Repository.Delete((int)id);
            return vehicleUnit.Commit();
        }

        public async Task<int> DeleteAsync(VehicleDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            vehicleUnit.Repository.Delete(entity.Id);
            return await vehicleUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            vehicleUnit.Repository.Delete((int)id);
            return await vehicleUnit.CommitAsync();
        }

        public void Dispose()
        {
            vehicleUnit.Dispose();
        }

        public IEnumerable<VehicleDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Vehicle>, List<VehicleDTO>>(vehicleUnit.Repository.GetAll());
        }

        public async Task<List<VehicleDTO>> GetAllAsync()
        {
            return Mapper.Map<List<Vehicle>, List<VehicleDTO>>(await vehicleUnit.Repository.GetAllAsync());
        }

        public VehicleDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Vehicle, VehicleDTO>(vehicleUnit.Repository.GetById((int)id));
        }

        public async Task<VehicleDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Vehicle, VehicleDTO>(await vehicleUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<VehicleDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<Vehicle>, List<VehicleDTO>>(await vehicleUnit.Repository.GetManyAsync(p =>
                    p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(VehicleDTO entity)
        {
            var model = Mapper.Map<VehicleDTO, Vehicle>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            vehicleUnit.Repository.Insert(model);
            return vehicleUnit.Commit();
        }

        public async Task<int> InsertAsync(VehicleDTO entity)
        {
            var model = Mapper.Map<VehicleDTO, Vehicle>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            vehicleUnit.Repository.Insert(model);
            return await vehicleUnit.CommitAsync();
        }

        public int Update(VehicleDTO entity)
        {
            var model = vehicleUnit.Repository.GetById(entity.Id);
            MapVehicle(entity, model);
            vehicleUnit.Repository.Insert(model);
            return vehicleUnit.Commit();
        }

        private static void MapVehicle(VehicleDTO entity, Vehicle model)
        {
            model.BrandId = entity.BrandId;
            model.Comments = entity.Comments;
            model.EngineCapacity = entity.EngineCapacity;
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.Load = entity.Load;
            model.ModelId = entity.ModelId;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.OperationFrom = entity.OperationFrom;
            model.ParentId = entity.ParentId;
            model.PlaceOfRegistration = entity.PlaceOfRegistration;
            model.RegNumber = entity.RegNumber;
            model.SertificateDate = entity.SertificateDate;
            model.SertificateIssuer = entity.SertificateIssuer;
            model.SertificateNumber = entity.SertificateNumber;
            model.SertificateSeries = entity.SertificateSeries;
            model.Vin = entity.Vin;
        }

        public async Task<int> UpdateAsync(VehicleDTO entity)
        {
            var model = await  vehicleUnit.Repository.GetAsync(p => p.Id == entity.Id);
            MapVehicle(entity, model);
            vehicleUnit.Repository.Insert(model);
            return await vehicleUnit.CommitAsync();
        }
    }
}
