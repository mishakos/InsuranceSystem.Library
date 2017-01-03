namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using UnitOfWork;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;

    public class SalesOfficeService : ISalesOfficeService
    {
        readonly IUnitOfWork<SalesOffice> soUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public SalesOfficeService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            soUnit = new SalesOfficeUnit();
        }

        public int Delete(SalesOfficeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            soUnit.Repository.Delete(entity.Id);
            return soUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            soUnit.Repository.Delete((int)id);
            return soUnit.Commit();
        }

        public async Task<int> DeleteAsync(SalesOfficeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            soUnit.Repository.Delete(entity.Id);
            return await soUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            soUnit.Repository.Delete((int)id);
            return await soUnit.CommitAsync();
        }

        public void Dispose()
        {
            soUnit.Dispose();
        }

        public IEnumerable<SalesOfficeDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<SalesOffice>, List<SalesOfficeDTO>>(soUnit.Repository.GetAll());
        }

        public async Task<List<SalesOfficeDTO>> GetAllAsync()
        {
            return Mapper.Map<List<SalesOffice>, List<SalesOfficeDTO>>(await soUnit.Repository.GetAllAsync());
        }

        public SalesOfficeDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<SalesOffice, SalesOfficeDTO>(soUnit.Repository.GetById((int)id));
        }

        public async Task<SalesOfficeDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<SalesOffice, SalesOfficeDTO>(await soUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<SalesOfficeDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<SalesOffice>, List<SalesOfficeDTO>>(await soUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(SalesOfficeDTO entity)
        {
            var model = Mapper.Map<SalesOfficeDTO, SalesOffice>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            soUnit.Repository.Insert(model);
            return soUnit.Commit();
        }

        public async Task<int> InsertAsync(SalesOfficeDTO entity)
        {
            var model = Mapper.Map<SalesOfficeDTO, SalesOffice>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            soUnit.Repository.Insert(model);
            return await soUnit.CommitAsync();
        }

        public int Update(SalesOfficeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var model = soUnit.Repository.GetById(entity.Id);
            MapSalesOffice(entity, model);
            soUnit.Repository.Update(model);
            return soUnit.Commit();
        }

        private void MapSalesOffice(SalesOfficeDTO entity, SalesOffice model)
        {
            model.DepartmentId = entity.DepartmentId;
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(SalesOfficeDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var model = await soUnit.Repository.GetAsync(p => p.Id == entity.Id);
            MapSalesOffice(entity, model);
            soUnit.Repository.Update(model);
            return await soUnit.CommitAsync();
        }
    }
}
