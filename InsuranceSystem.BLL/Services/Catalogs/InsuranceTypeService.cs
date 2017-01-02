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

    public class InsuranceTypeService : IInsuranceTypeService
    {
        readonly IUnitOfWork<InsuranceType> itUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public InsuranceTypeService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            itUnit = new InsuranceTypeUnit();
        }

        public int Delete(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            itUnit.Repository.Delete(entity.Id);
            return itUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            itUnit.Repository.Delete((int)id);
            return itUnit.Commit();
        }

        public async Task<int> DeleteAsync(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            itUnit.Repository.Delete(entity.Id);
            return await itUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            itUnit.Repository.Delete((int)id);
            return await itUnit.CommitAsync();
        }

        public void Dispose()
        {
            itUnit.Dispose();
        }

        public IEnumerable<InsuranceTypeDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<InsuranceTypeDTO>>(itUnit.Repository.GetAll());
        }

        public async Task<List<InsuranceTypeDTO>> GetAllAsync()
        {
            return Mapper.Map<List<InsuranceTypeDTO>>(await itUnit.Repository.GetAllAsync());
        }

        public InsuranceTypeDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<InsuranceTypeDTO>(itUnit.Repository.GetById((int)id));
        }

        public async Task<InsuranceTypeDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return await Mapper.Map<Task<InsuranceTypeDTO>>(itUnit.Repository.GetAsync((p => p.Id == id)));
        }

        public async Task<List<InsuranceTypeDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<InsuranceTypeDTO>>(await itUnit.Repository.GetManyAsync(p => p.Name.ToUpper()
            .Contains(name.ToUpper())));
        }

        public int Insert(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            InsuranceType item = MapNewItem(entity);
            itUnit.Repository.Insert(item);
            return itUnit.Commit();
        }

        private static InsuranceType MapNewItem(InsuranceTypeDTO entity)
        {
            var item = new InsuranceType();
            item.DateCreate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            InsuranceType item = MapNewItem(entity);
            itUnit.Repository.Insert(item);
            return await itUnit.CommitAsync();
        }

        public int Update(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = itUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            itUnit.Repository.Update(item);
            return itUnit.Commit();
        }

        private static void MapExistingItem(InsuranceTypeDTO entity, InsuranceType item)
        {
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(InsuranceTypeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = itUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            itUnit.Repository.Update(item);
            return await itUnit.CommitAsync();
        }
    }
}
