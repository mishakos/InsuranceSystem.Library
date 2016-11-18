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

    public class BrandService : IBrandService, IService<BrandDTO>
    {
        readonly IUnitOfWork<Brand> brandUnit;

        public BrandService()
        {
            brandUnit = new BrandUnit();
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
            Mapper.CreateMap<Brand, BrandDTO>();
            return Mapper.Map<IEnumerable<Brand>, IEnumerable<BrandDTO>>(brandUnit
                .Repository.GetAll());
        }

        public async Task<List<BrandDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Brand, BrandDTO>();
            return await Mapper.Map<Task<List<Brand>>, Task<List<BrandDTO>>>(brandUnit
                .Repository.GetAllAsync());
        }

        public BrandDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Brand, BrandDTO>();
            return Mapper.Map<Brand, BrandDTO>(brandUnit.Repository.GetById((int)id));
        }

        public async Task<BrandDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Brand, BrandDTO>();
            return await Mapper.Map<Task<Brand>, Task<BrandDTO>>(brandUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BrandDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Brand, BrandDTO>();
            return await Mapper.Map<Task<List<Brand>>, Task<List<BrandDTO>>>(brandUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(BrandDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BrandDTO, Brand>();
            brandUnit.Repository.Insert(Mapper.Map<BrandDTO, Brand>(entity));
            return brandUnit.Commit();
        }

        public async Task<int> InsertAsync(BrandDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BrandDTO, Brand>();
            brandUnit.Repository.Insert(Mapper.Map<BrandDTO, Brand>(entity));
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
