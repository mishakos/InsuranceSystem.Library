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

    /// <summary>
    /// Areas of use - Catalog of Areas of use vehicles.
    /// used in calculation rate of MTPL Policy
    /// </summary>
    public class AreaOfUseService : IAreaOfUseService
    {
        /// <summary>
        /// Connection to data layer by unit of work.
        /// </summary>
        readonly IUnitOfWork<AreaOfUse> areaOfUseUnit;
        public AreaOfUseService()
        {
            areaOfUseUnit = new AreasOfUseUnit();
        }

        public int Delete(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            areaOfUseUnit.Repository.Delete(entity.Id);
            return areaOfUseUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            areaOfUseUnit.Repository.Delete((int)id);
            return areaOfUseUnit.Commit();
        }

        public Task<int> DeleteAsync(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            areaOfUseUnit.Repository.Delete(entity.Id);
            return areaOfUseUnit.CommitAsync();
        }

        public Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            areaOfUseUnit.Repository.Delete((int)id);
            return areaOfUseUnit.CommitAsync();
        }

        public void Dispose()
        {
            areaOfUseUnit.Dispose();
        }

        public IEnumerable<AreaOfUseDTO> GetAll()
        {
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return Mapper.Map<IEnumerable<AreaOfUse>, List<AreaOfUseDTO>>(
                areaOfUseUnit.Repository.GetAll());
        }

        public async Task<List<AreaOfUseDTO>> GetAllAsync()
        {
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return Mapper.Map<List<AreaOfUse>,List<AreaOfUseDTO>>(await
                areaOfUseUnit.Repository.GetAllAsync());
        }

        public AreaOfUseDTO GetById(int? id)
        {
            CheckForNull(id);
            var item = areaOfUseUnit.Repository.GetById((int)id);
            CheckForNull(item);
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return Mapper.Map<AreaOfUse, AreaOfUseDTO>(item);
        }

        public async Task<AreaOfUseDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return  Mapper.Map<AreaOfUse, AreaOfUseDTO>(await
                areaOfUseUnit.Repository.GetAsync(x => x.Id == id));
        }

        public int Insert(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            entity.DateCreate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            Mapper.CreateMap<AreaOfUseDTO, AreaOfUse>();
            areaOfUseUnit.Repository.Insert(Mapper.Map<AreaOfUseDTO, AreaOfUse>(entity));
            return areaOfUseUnit.Commit();
        }

        public async Task<int> InsertAsync(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            entity.DateCreate = DateTime.Now;
            entity.ModifiedDate = DateTime.Now;
            Mapper.CreateMap<AreaOfUseDTO, AreaOfUse>();
            areaOfUseUnit.Repository.Insert(Mapper.Map<AreaOfUseDTO, AreaOfUse>(entity));
            return await areaOfUseUnit.CommitAsync();
        }

        public int Update(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            AreaOfUse item = FillAreaOfUse(entity);

            areaOfUseUnit.Repository.Update(item);
            return areaOfUseUnit.Commit();
        }

        private AreaOfUse FillAreaOfUse(AreaOfUseDTO entity)
        {
            var item = areaOfUseUnit.Repository.GetById(entity.Id);
            item.ModifiedDate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = item.Name;
            item.ParentId = item.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(AreaOfUseDTO entity)
        {
            CheckForNull(entity);
            AreaOfUse item = FillAreaOfUse(entity);

            areaOfUseUnit.Repository.Update(item);
            return await areaOfUseUnit.CommitAsync();
        }

        public async Task<List<AreaOfUseDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return Mapper.Map<List<AreaOfUse>, List<AreaOfUseDTO>>(await areaOfUseUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public async Task<List<AreaOfUseDTO>> GetByParentAsync(int? id)
        {
            Mapper.CreateMap<AreaOfUse, AreaOfUseDTO>();
            return Mapper.Map<List<AreaOfUse>, List<AreaOfUseDTO>>(await areaOfUseUnit
                .Repository.GetManyAsync(p => p.ParentId == id));
        }
    }
}
