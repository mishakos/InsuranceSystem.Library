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
    public class DepartmentService : IDepartmentService, IService<DepartmentDTO>
    {
        readonly IUnitOfWork<Department> departmentUnit;

        public DepartmentService()
        {
            departmentUnit = new DepartmentUnit();
        }

        public int Delete(DepartmentDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            departmentUnit.Repository.Delete(entity.Id);
            return departmentUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            departmentUnit.Repository.Delete((int)id);
            return departmentUnit.Commit();
        }

        public async Task<int> DeleteAsync(DepartmentDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            departmentUnit.Repository.Delete(entity.Id);
            return await departmentUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            departmentUnit.Repository.Delete((int)id);
            return await departmentUnit.CommitAsync();
        }

        public void Dispose()
        {
            departmentUnit.Dispose();
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            Mapper.CreateMap<Department, DepartmentDTO>();
            return Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDTO>>(departmentUnit
                .Repository.GetAll());
        }

        public async Task<List<DepartmentDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Department, DepartmentDTO>();
            return await Mapper.Map<Task<List<Department>>, Task<List<DepartmentDTO>>>(departmentUnit
                .Repository.GetAllAsync()); 
        }

        public async Task<List<DepartmentDTO>> GetByFirmIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Department, DepartmentDTO>();
            return await Mapper.Map<Task<List<Department>>, Task<List<DepartmentDTO>>>(
                departmentUnit.Repository.GetManyAsync(p => p.FirmId == id));
        }

        public DepartmentDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Department, DepartmentDTO>();
            return Mapper.Map<Department, DepartmentDTO>(departmentUnit.Repository.GetById((int)id));
        }

        public async Task<DepartmentDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Department, DepartmentDTO>();
            return await Mapper.Map<Task<Department>, Task<DepartmentDTO>>(departmentUnit.Repository
                .GetAsync(p => p.Id == id));
        }

        public async Task<List<DepartmentDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Department, DepartmentDTO>();
            return await Mapper.Map<Task<List<Department>>, Task<List<DepartmentDTO>>>(departmentUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(DepartmentDTO entity)
        {
            CheckForNull(entity);
            Department item = GetNewItem(entity);
            departmentUnit.Repository.Insert(item);
            return departmentUnit.Commit();
        }

        private static Department GetNewItem(DepartmentDTO entity)
        {
            var item = new Department();
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            item.FirmId = entity.FirmId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(DepartmentDTO entity)
        {
            CheckForNull(entity);
            var item = GetNewItem(entity);
            departmentUnit.Repository.Insert(item);
            return await departmentUnit.CommitAsync();
        }

        public int Update(DepartmentDTO entity)
        {
            CheckForNull(entity);
            var item = departmentUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            UpdateItem(item, entity);
            departmentUnit.Repository.Update(item);
            return departmentUnit.Commit();
        }

        public async Task<int> UpdateAsync(DepartmentDTO entity)
        {
            CheckForNull(entity);
            var item = departmentUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            UpdateItem(item, entity);
            departmentUnit.Repository.Update(item);
            return await departmentUnit.CommitAsync();
        }

        private void UpdateItem(Department item, DepartmentDTO entity)
        {
            item.ModifiedDate = DateTime.Now;
            item.FirmId = entity.FirmId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
        }
    }
}
