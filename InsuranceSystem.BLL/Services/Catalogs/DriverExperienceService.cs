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

    public class DriverExperienceService : IDriverExperienceService, IService<DriverExperienceDTO>
    {
        readonly IUnitOfWork<DriverExperience> deUnit;
        public DriverExperienceService()
        {
            deUnit = new DriverExperienceUnit();
        }

        public int Delete(DriverExperienceDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            deUnit.Repository.Delete(entity.Id);
            return deUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            deUnit.Repository.Delete((int)id);
            return deUnit.Commit();
        }

        public async Task<int> DeleteAsync(DriverExperienceDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            deUnit.Repository.Delete(entity.Id);
            return await deUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            deUnit.Repository.Delete((int)id);
            return await deUnit.CommitAsync();
        }

        public void Dispose()
        {
            deUnit.Dispose();
        }

        public IEnumerable<DriverExperienceDTO> GetAll()
        {
            Mapper.CreateMap<DriverExperience, DriverExperienceDTO>();
            return Mapper.Map<IEnumerable<DriverExperience>, IEnumerable<DriverExperienceDTO>>(deUnit
                .Repository.GetAll());
        }

        public async Task<List<DriverExperienceDTO>> GetAllAsync()
        {
            Mapper.CreateMap<DriverExperience, DriverExperienceDTO>();
            return Mapper.Map<List<DriverExperience>, List<DriverExperienceDTO>>(await deUnit
                .Repository.GetAllAsync());
        }

        public DriverExperienceDTO GetById(int? id)
        {
            CheckForNull(id);
            var item = deUnit.Repository.GetById((int)id);
            CheckForNull(item);
            Mapper.CreateMap<DriverExperience, DriverExperienceDTO>();
            return Mapper.Map<DriverExperience, DriverExperienceDTO>(item);
        }

        public async Task<DriverExperienceDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<DriverExperience, DriverExperienceDTO>();
            return  Mapper.Map<DriverExperience, DriverExperienceDTO>(await deUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<DriverExperienceDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<DriverExperience, DriverExperienceDTO>();
            return Mapper.Map<List<DriverExperience>, List<DriverExperienceDTO>>(await deUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(DriverExperienceDTO entity)
        {
            DriverExperience item = FillNewItem(entity);
            deUnit.Repository.Insert(item);
            return deUnit.Commit();
        }

        private static DriverExperience FillNewItem(DriverExperienceDTO entity)
        {
            CheckForNull(entity);
            var item = new DriverExperience();
            item.DateCreate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(DriverExperienceDTO entity)
        {
            DriverExperience item = FillNewItem(entity);
            deUnit.Repository.Insert(item);
            return await deUnit.CommitAsync();
        }

        public int Update(DriverExperienceDTO entity)
        {
           var item = UpdateItemInfo(entity);
            deUnit.Repository.Update(item);
            return deUnit.Commit();
        }

        private DriverExperience UpdateItemInfo(DriverExperienceDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = deUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(DriverExperienceDTO entity)
        {
            var item = UpdateItemInfo(entity);
            deUnit.Repository.Update(item);
            return await deUnit.CommitAsync();
        }
    }
}
