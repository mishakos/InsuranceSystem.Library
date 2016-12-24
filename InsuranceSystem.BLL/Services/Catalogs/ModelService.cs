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

    public class ModelService : IModelService, IService<ModelDTO>
    {
        readonly IUnitOfWork<Model> mUnit;

        public ModelService()
        {
            Mapper.CreateMap<Model, ModelDTO>();
            mUnit = new ModelUnit();
        }

        public int Delete(ModelDTO entity)
        {
            CheckForNull(entity);
            mUnit.Repository.Delete(entity.Id);
            return mUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            mUnit.Repository.Delete((int)id);
            return mUnit.Commit();
        }

        public async Task<int> DeleteAsync(ModelDTO entity)
        {
            CheckForNull(entity);
            mUnit.Repository.Delete(entity.Id);
            return await mUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            mUnit.Repository.Delete((int)id);
            return await mUnit.CommitAsync();
        }

        public void Dispose()
        {
            mUnit.Dispose();
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<ModelDTO>>(mUnit.Repository.GetAll());
        }

        public async Task<List<ModelDTO>> GetAllAsync()
        {
            return Mapper.Map<List<ModelDTO>>(await mUnit.Repository.GetAllAsync());
        }

        public ModelDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<ModelDTO>(mUnit.Repository.GetById((int)id));
        }

        public async Task<ModelDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<ModelDTO>(await mUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async  Task<List<ModelDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<ModelDTO>>(await mUnit.Repository.GetManyAsync(p => p.Name.ToUpper()
            .Contains(name.ToUpper())));
        }

        public int Insert(ModelDTO entity)
        {
            CheckForNull(entity);
            var item = new Model();
            MapNewItem(entity, item);
            mUnit.Repository.Insert(item);
            return mUnit.Commit();
        }

        private static void MapNewItem(ModelDTO entity, Model item)
        {
            item.DateCreate = DateTime.Now;
            item.BrandId = entity.BrandId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> InsertAsync(ModelDTO entity)
        {
            CheckForNull(entity);
            var item = new Model();
            MapNewItem(entity, item);
            mUnit.Repository.Insert(item);
            return await mUnit.CommitAsync();
        }

        public int Update(ModelDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = mUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            mUnit.Repository.Update(item);
            return mUnit.Commit();
        }

        private static void MapExistingItem(ModelDTO entity, Model item)
        {
            item.BrandId = entity.BrandId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(ModelDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = mUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            mUnit.Repository.Update(item);
            return await mUnit.CommitAsync();
        }
    }
}
