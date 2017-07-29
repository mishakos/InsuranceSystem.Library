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

    public class BrandService : IBrandService
    {
        readonly IUnitOfWork<Brand> brandUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public BrandService()
        {
            brandUnit = new BrandUnit();
            autoMapperConfig = AutoMapperConfig.Instance;
        }

        public int Delete(BrandDTO entity)
        {
            DeleteBrand(entity);
            return brandUnit.Commit();
        }

        private void DeleteBrand(BrandDTO entity)
        {
            CheckForNull(entity);
            brandUnit.Repository.Delete(entity.Id);
        }

        public int Delete(int? id)
        {
            DeleteBrand(id);
            return brandUnit.Commit();
        }

        private void DeleteBrand(int? id)
        {
            CheckForNull(id);
            brandUnit.Repository.Delete((int)id);
        }

        public async Task<int> DeleteAsync(BrandDTO entity)
        {
            DeleteBrand(entity);
            return await brandUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            DeleteBrand(id);
            return await brandUnit.CommitAsync();
        }

        public void Dispose()
        {
            brandUnit.Dispose();
        }

        public IEnumerable<BrandDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDTO>>(brandUnit
                .Repository.GetAll());
        }

        public async Task<List<BrandDTO>> GetAllAsync()
        {
            return Mapper.Map<List<Brand>, List<BrandDTO>>(await brandUnit
                .Repository.GetAllAsync());
        }

        public BrandDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Brand, BrandDTO>(brandUnit.Repository.GetById((int)id));
        }

        public async Task<BrandDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return  Mapper.Map<Brand, BrandDTO>(await brandUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BrandDTO>> GetByNameAsync(string name)
        {
            return  Mapper.Map<List<Brand>, List<BrandDTO>>(await brandUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper()
                .Contains(name.ToUpper())));
        }

        public int Insert(BrandDTO entity)
        {
            CheckForNull(entity);
            var model = Mapper.Map<BrandDTO, Brand>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            brandUnit.Repository.Insert(model);
            return brandUnit.Commit();
        }

        public async Task<int> InsertAsync(BrandDTO entity)
        {
            CheckForNull(entity);
            var model = Mapper.Map<BrandDTO, Brand>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            brandUnit.Repository.Insert(model);
            return await brandUnit.CommitAsync();
        }

        public int Update(BrandDTO entity)
        {
            Brand item = FillBrandItem(entity);
            brandUnit.Repository.Update(item);
            return brandUnit.Commit();
        }

        private Brand FillBrandItem(BrandDTO entity)
        {
            CheckForNull(entity);
            var item = brandUnit.Repository.GetById(entity.Id);
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(BrandDTO entity)
        {
            Brand item = FillBrandItem(entity);
            brandUnit.Repository.Update(item);
            return await brandUnit.CommitAsync();
        }
    }
}
