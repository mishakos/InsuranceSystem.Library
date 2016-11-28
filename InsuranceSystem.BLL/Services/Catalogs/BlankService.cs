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

    public class BlankService : IBlankService, IService<BlankDTO>
    {
        readonly IUnitOfWork<Blank> blankUnit;
        public BlankService()
        {
            blankUnit = new BlankUnit();
        }

        public int Delete(BlankDTO entity)
        {
            CheckForNull(entity);
            blankUnit.Repository.Delete(entity.Id);
            return blankUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            blankUnit.Repository.Delete((int)id);
            return blankUnit.Commit();
        }

        public async Task<int> DeleteAsync(BlankDTO entity)
        {
            CheckForNull(entity);
            blankUnit.Repository.Delete(entity.Id);
            return await blankUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            blankUnit.Repository.Delete((int)id);
            return await blankUnit.CommitAsync();
        }

        public void Dispose()
        {
            blankUnit.Dispose();
        }

        public IEnumerable<BlankDTO> GetAll()
        {
            Mapper.CreateMap<Blank, BlankDTO>();
            return Mapper.Map<IEnumerable<Blank>, IEnumerable<BlankDTO>>
                (blankUnit.Repository.GetAll());
        }

        public async Task<List<BlankDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Task<Blank>, Task<BlankDTO>>();
            return await Mapper.Map<Task<List<Blank>>, Task<List<BlankDTO>>>
                (blankUnit.Repository.GetAllAsync());
        }

        public async Task<List<BlankDTO>> GetByBlankTypeId(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Blank, BlankDTO>();
            return await Mapper.Map<Task<List<Blank>>, Task<List<BlankDTO>>>
                (blankUnit.Repository.GetManyAsync(p => p.BlankTypeId == id));
        }

        public BlankDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Blank, BlankDTO>();
            return Mapper.Map<Blank, BlankDTO>
                (blankUnit.Repository.GetById((int)id));
        }

        public Task<BlankDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Blank, BlankDTO>();
            return Mapper.Map<Task<Blank>, Task<BlankDTO>>
                (blankUnit.Repository.GetAsync(p => p.Id == id));
        }

        public int Insert(BlankDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BlankDTO, Blank>();
            var item = Mapper.Map<BlankDTO, Blank>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            blankUnit.Repository.Insert(item);
            return blankUnit.Commit();
        }

        public async Task<int> InsertAsync(BlankDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BlankDTO, Blank>();
            var item = Mapper.Map<BlankDTO, Blank>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            blankUnit.Repository.Insert(item);
            return await blankUnit.CommitAsync();
        }

        public int Update(BlankDTO entity)
        {
            CheckForNull(entity);
            Blank item = FillBlank(entity);
            blankUnit.Repository.Insert(item);
            return blankUnit.Commit();
        }

        private Blank FillBlank(BlankDTO entity)
        {
            var item = blankUnit.Repository.GetById(entity.Id);
            item.BlankTypeId = entity.BlankTypeId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public async Task<int> UpdateAsync(BlankDTO entity)
        {
            CheckForNull(entity);
            Blank item = FillBlank(entity);
            blankUnit.Repository.Insert(item);
            return await blankUnit.CommitAsync();
        }

        public async Task<List<BlankDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Blank, BlankDTO>();
            return await Mapper.Map<Task<List<Blank>>, Task<List<BlankDTO>>>(blankUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }
    }
}
