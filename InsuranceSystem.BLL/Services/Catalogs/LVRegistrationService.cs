namespace InsuranceSystem.BLL.Services.Catalogs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using DTO.Catalogs;
    using Interfaces;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using UnitOfWork;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;
    using InsuranceSystem.BLL.Infrastructure;

    public class LVRegistrationService : ILocalityVehicleRegistrationService
    {
        readonly IUnitOfWork<LocalityVehicleRegistration> lvrUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public LVRegistrationService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            lvrUnit = new LocalityVehicleRegistrationUnit();
        }

        public int Delete(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            lvrUnit.Repository.Delete(entity.Id);
            return lvrUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            lvrUnit.Repository.Delete((int)id);
            return lvrUnit.Commit();
        }

        public async Task<int> DeleteAsync(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            lvrUnit.Repository.Delete(entity.Id);
            return await lvrUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            lvrUnit.Repository.Delete((int)id);
            return await lvrUnit.CommitAsync();
        }

        public void Dispose()
        {
            lvrUnit.Dispose();
        }

        public IEnumerable<LocalityVehicleRegistrationDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<LocalityVehicleRegistrationDTO>>(lvrUnit.Repository.GetAll());
        }

        public async Task<List<LocalityVehicleRegistrationDTO>> GetAllAsync()
        {
            return Mapper.Map<List<LocalityVehicleRegistrationDTO>>(await lvrUnit.Repository.GetAllAsync());
        }

        public LocalityVehicleRegistrationDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<LocalityVehicleRegistrationDTO>(lvrUnit.Repository.GetById((int)id));
        }

        public async  Task<LocalityVehicleRegistrationDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<LocalityVehicleRegistrationDTO>( await lvrUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<LocalityVehicleRegistrationDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<LocalityVehicleRegistrationDTO>>(await lvrUnit.Repository.GetManyAsync(p => p.Name
            .ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            var item = new LocalityVehicleRegistration();
            MapNewItem(entity, item);
            lvrUnit.Repository.Insert(item);
            return lvrUnit.Commit();
        }

        private static void MapNewItem(LocalityVehicleRegistrationDTO entity, LocalityVehicleRegistration item)
        {
            item.DateCreate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> InsertAsync(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            var item = new LocalityVehicleRegistration();
            MapNewItem(entity, item);
            lvrUnit.Repository.Insert(item);
            return await lvrUnit.CommitAsync();
        }

        public int Update(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            var item = lvrUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            lvrUnit.Repository.Update(item);
            return lvrUnit.Commit();
        }

        private static void MapExistingItem(LocalityVehicleRegistrationDTO entity, LocalityVehicleRegistration item)
        {
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(LocalityVehicleRegistrationDTO entity)
        {
            CheckForNull(entity);
            var item = lvrUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            lvrUnit.Repository.Update(item);
            return await lvrUnit.CommitAsync();
        }
    }
}
