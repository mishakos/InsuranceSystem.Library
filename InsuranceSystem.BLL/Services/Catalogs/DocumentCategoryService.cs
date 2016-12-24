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
    public class DocumentCategoryService : IDocumentCategoryService, IService<DocumentCategoryDTO>
    {
        readonly IUnitOfWork<DocumentCategory> dcUnit;

        public DocumentCategoryService()
        {
            dcUnit = new DocumentCategoryUnit();
        }

        public int Delete(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            dcUnit.Repository.Delete(entity.Id);
            return dcUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            dcUnit.Repository.Delete((int)id);
            return dcUnit.Commit();
        }

        public async Task<int> DeleteAsync(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            dcUnit.Repository.Delete(entity.Id);
            return await dcUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            dcUnit.Repository.Delete((int)id);
            return await dcUnit.CommitAsync();
        }

        public void Dispose()
        {
            dcUnit.Dispose();
        }

        public IEnumerable<DocumentCategoryDTO> GetAll()
        {
            Mapper.CreateMap<DocumentCategory, DocumentCategoryDTO>();
            return Mapper.Map<IEnumerable<DocumentCategory>, IEnumerable<DocumentCategoryDTO>>(dcUnit
                .Repository.GetAll());
        }

        public async Task<List<DocumentCategoryDTO>> GetAllAsync()
        {
            Mapper.CreateMap<DocumentCategory, DocumentCategoryDTO>();
            return  Mapper.Map<List<DocumentCategory>, List<DocumentCategoryDTO>>(await dcUnit
                .Repository.GetAllAsync());
        }

        public DocumentCategoryDTO GetById(int? id)
        {
            CheckForNull(id);
            var item = dcUnit.Repository.GetById((int)id);
            CheckForNull(item);
            Mapper.CreateMap<DocumentCategory, DocumentCategoryDTO>();
            return Mapper.Map<DocumentCategory, DocumentCategoryDTO>(item);
        }

        public async Task<DocumentCategoryDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<DocumentCategory, DocumentCategoryDTO>();
            return  Mapper.Map<DocumentCategory, DocumentCategoryDTO>(await dcUnit
                .Repository.GetAsync(p => p.Id == (int)id));
        }

        public async Task<List<DocumentCategoryDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<DocumentCategory, DocumentCategoryDTO>();
            return  Mapper.Map<List<DocumentCategory>, List<DocumentCategoryDTO>>(await dcUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            GetNewItem(entity);
            return dcUnit.Commit();
        }

        private void GetNewItem(DocumentCategoryDTO entity)
        {
            var newItem = new DocumentCategory();
            newItem.DateCreate = DateTime.Now;
            newItem.ModifiedDate = DateTime.Now;
            newItem.IsDelete = false;
            newItem.IsGroup = entity.IsGroup;
            newItem.Name = entity.Name;
            newItem.ParentId = entity.ParentId;
            dcUnit.Repository.Insert(newItem);
        }

        public async Task<int> InsertAsync(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            GetNewItem(entity);
            return await dcUnit.CommitAsync();
        }

        public int Update(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            UpdateItem(entity);
            return dcUnit.Commit();
        }

        private void UpdateItem(DocumentCategoryDTO entity)
        {
            var item = dcUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            item.IsDelete = item.IsDelete;
            dcUnit.Repository.Update(item);
        }

        public async Task<int> UpdateAsync(DocumentCategoryDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            UpdateItem(entity);
            return await dcUnit.CommitAsync();
        }
    }
}
