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
            CheckForNull(entity);
            CheckForNull(entity.Id);
            trUnit.Repository.Delete(entity.Id);
            return trUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            trUnit.Repository.Delete((int)id);
            return trUnit.Commit();
        }

        public async Task<int> DeleteAsync(TerritoryRegistrationDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            trUnit.Repository.Delete(entity.Id);
            return await trUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            trUnit.Repository.Delete((int)id);
            return await trUnit.CommitAsync();
        }

        public void Dispose()
        {
            trUnit.Dispose();
        }

        public IEnumerable<TerritoryRegistrationDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<TerritoryRegistration>, List<TerritoryRegistrationDTO>>(trUnit.Repository.GetAll());
        }

        public async Task<List<TerritoryRegistrationDTO>> GetAllAsync()
        {
            return Mapper.Map<List<TerritoryRegistration>, List<TerritoryRegistrationDTO>>(await trUnit.Repository.GetAllAsync());
        }

        public TerritoryRegistrationDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<TerritoryRegistration, TerritoryRegistrationDTO>(
                trUnit.Repository.GetById((int)id));
        }

        public async Task<TerritoryRegistrationDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<TerritoryRegistration, TerritoryRegistrationDTO>(
                await trUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<TerritoryRegistrationDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<TerritoryRegistration>, List<TerritoryRegistrationDTO>>(
                await trUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(TerritoryRegistrationDTO entity)
        {
            var model = Mapper.Map<TerritoryRegistrationDTO, TerritoryRegistration>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            trUnit.Repository.Insert(model);
            return trUnit.Commit();
        }

        public async Task<int> InsertAsync(TerritoryRegistrationDTO entity)
        {
            var model = Mapper.Map<TerritoryRegistrationDTO, TerritoryRegistration>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            trUnit.Repository.Insert(model);
            return await trUnit.CommitAsync();
        }

        public int Update(TerritoryRegistrationDTO entity)
        {
            var model = trUnit.Repository.GetById(entity.Id);
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
            trUnit.Repository.Update(model);
            return trUnit.Commit();
        }

        public async Task<int> UpdateAsync(TerritoryRegistrationDTO entity)
        {
            var model = await trUnit.Repository.GetAsync(p => p.Id == entity.Id);
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
            trUnit.Repository.Update(model);
            return await trUnit.CommitAsync();
        }
    }
}
