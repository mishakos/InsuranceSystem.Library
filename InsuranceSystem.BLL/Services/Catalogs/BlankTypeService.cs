
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

    public class BlankTypeService : IBlankTypeService, IService<BlankTypeDTO>
    {
        readonly IUnitOfWork<BlankType> blankTypeUnit;
        public BlankTypeService()
        {
            blankTypeUnit = new BlankTypeUnit();
        }

        public int Delete(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            blankTypeUnit.Repository.Delete(entity.Id);
            return blankTypeUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            blankTypeUnit.Repository.Delete((int)id);
            return blankTypeUnit.Commit();
        }

        public async Task<int> DeleteAsync(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            blankTypeUnit.Repository.Delete(entity.Id);
            return await blankTypeUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            blankTypeUnit.Repository.Delete((int)id);
            return await blankTypeUnit.CommitAsync();
        }

        public void Dispose()
        {
            blankTypeUnit.Dispose();
        }

        public IEnumerable<BlankTypeDTO> GetAll()
        {
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return Mapper.Map<IEnumerable<BlankType>, IEnumerable<BlankTypeDTO>>
                (blankTypeUnit.Repository.GetAll());
        }

        public async Task<List<BlankTypeDTO>> GetAllAsync()
        {
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return Mapper.Map<List<BlankType>, List<BlankTypeDTO>>
                ( await blankTypeUnit.Repository.GetAllAsync());
        }

        public BlankTypeDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return Mapper.Map<BlankType, BlankTypeDTO>(blankTypeUnit.Repository.GetById((int)id));
        }

        public async Task<BlankTypeDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return await Mapper.Map<Task<BlankType>, Task<BlankTypeDTO>>
                (blankTypeUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BlankTypeDTO>> GetByName(string name)
        {
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return await Mapper.Map<Task<List<BlankType>>, Task<List<BlankTypeDTO>>>
                (blankTypeUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BlankTypeDTO, BlankType>();
            var item = Mapper.Map<BlankTypeDTO, BlankType>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            blankTypeUnit.Repository.Insert(item);
            return blankTypeUnit.Commit();
        }

        public async Task<int> InsertAsync(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BlankTypeDTO, BlankType>();
            var item = Mapper.Map<BlankTypeDTO, BlankType>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            blankTypeUnit.Repository.Insert(item);
            return await blankTypeUnit.CommitAsync();
         }

        public int Update(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            BlankType item = FillBlankType(entity);
            blankTypeUnit.Repository.Update(item);
            return blankTypeUnit.Commit();
        }

        private BlankType FillBlankType(BlankTypeDTO entity)
        {
            var item = blankTypeUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.ModifiedDate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(BlankTypeDTO entity)
        {
            CheckForNull(entity);
            BlankType item = FillBlankType(entity);
            blankTypeUnit.Repository.Update(item);
            return await blankTypeUnit.CommitAsync();
        }

        public async Task<List<BlankTypeDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<BlankType, BlankTypeDTO>();
            return await Mapper.Map<Task<List<BlankType>>, Task<List<BlankTypeDTO>>>(blankTypeUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }
    }
}
