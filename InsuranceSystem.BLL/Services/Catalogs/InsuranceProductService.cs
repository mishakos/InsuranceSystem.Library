namespace InsuranceSystem.BLL.Services.Catalogs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using DTO.Catalogs;
    using InsuranceSystem.UnitOfWork.Catalogs;
    using Interfaces;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using UnitOfWork;
    using static Validation.CheckValues;

    public class InsuranceProductService : IInsuranceProductService, IService<InsuranceProductDTO>
    {
        readonly IUnitOfWork<InsuranceProduct> ipUnit;

        public InsuranceProductService()
        {
            Mapper.CreateMap<InsuranceProduct, InsuranceProductDTO>();
            ipUnit = new InsuranceProductUnit();
        }

        public int Delete(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            ipUnit.Repository.Delete(entity.Id);
            return ipUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            ipUnit.Repository.Delete((int)id);
            return ipUnit.Commit();
        }

        public async Task<int> DeleteAsync(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            ipUnit.Repository.Delete(entity.Id);
            return await ipUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            ipUnit.Repository.Delete((int)id);
            return await ipUnit.CommitAsync();
        }

        public void Dispose()
        {
            ipUnit.Dispose();
        }

        public IEnumerable<InsuranceProductDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<InsuranceProductDTO>>(ipUnit.Repository.GetAll());
        }

        public async Task<List<InsuranceProductDTO>> GetAllAsync()
        {
            return await Mapper.Map<Task<List<InsuranceProduct>>, Task<List<InsuranceProductDTO>>>(ipUnit
                .Repository.GetAllAsync());
        }

        public InsuranceProductDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<InsuranceProductDTO>(ipUnit.Repository.GetById((int)id));
        }

        public async Task<InsuranceProductDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return await Mapper.Map<Task<InsuranceProductDTO>>(ipUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<InsuranceProductDTO>> GetByNameAsync(string name)
        {
            return await Mapper.Map<Task<List<InsuranceProductDTO>>>(ipUnit.Repository.GetManyAsync(p => p.Name.ToUpper()
                    .Contains(name.ToUpper())));
        }

        public int Insert(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            MapNuewItem(entity);
            return ipUnit.Commit();
        }

        private void MapNuewItem(InsuranceProductDTO entity)
        {
            var item = new InsuranceProduct();
            item.DateCreate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            item.ShortKey = entity.ShortKey;
            ipUnit.Repository.Insert(item);
        }

        public async Task<int> InsertAsync(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            MapNuewItem(entity);
            return await ipUnit.CommitAsync();
        }

        public int Update(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = ipUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            return ipUnit.Commit();
        }

        private void MapExistingItem(InsuranceProductDTO entity, InsuranceProduct item)
        {
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            item.ShortKey = entity.ShortKey;
            ipUnit.Repository.Update(item);
        }

        public async Task<int> UpdateAsync(InsuranceProductDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = ipUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            return await ipUnit.CommitAsync();
        }
    }
}
