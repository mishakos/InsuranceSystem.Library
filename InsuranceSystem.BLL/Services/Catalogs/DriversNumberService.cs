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

    public class DriversNumberService : IDriversNumberService, IService<DriversNumberDTO>
    {
        readonly IUnitOfWork<DriversNumber> dnUnit;

        public DriversNumberService()
        {
            dnUnit = new DriversNumberUnit();
        }

        public int Delete(DriversNumberDTO entity)
        {
            CheckForNull(entity);
            deleteById(entity.Id);
            return dnUnit.Commit();
        }

        private void deleteById(int? id)
        {
            CheckForNull(id);
            dnUnit.Repository.Delete((int)id);
        }

        public int Delete(int? id)
        {
            deleteById(id);
            return dnUnit.Commit();
        }

        public async Task<int> DeleteAsync(DriversNumberDTO entity)
        {

            CheckForNull(entity);
            deleteById(entity.Id);
            return await dnUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            deleteById(id);
            return await dnUnit.CommitAsync();
        }

        public void Dispose()
        {
            dnUnit.Dispose();
        }

        public IEnumerable<DriversNumberDTO> GetAll()
        {
            Mapper.CreateMap<DriversNumber, DriversNumberDTO>();
            return Mapper.Map<IEnumerable<DriversNumber>, IEnumerable<DriversNumberDTO>>(dnUnit.Repository.GetAll());
        }

        public async Task<List<DriversNumberDTO>> GetAllAsync()
        {
            Mapper.CreateMap<DriversNumber, DriversNumberDTO>();
            return await Mapper.Map<Task<List<DriversNumber>>, Task<List<DriversNumberDTO>>>(dnUnit
                .Repository.GetAllAsync());
        }

        public DriversNumberDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<DriversNumber, DriversNumberDTO>();
            return Mapper.Map<DriversNumber, DriversNumberDTO>(dnUnit.Repository.GetById((int)id));
        }

        public async Task<DriversNumberDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<DriversNumber, DriversNumberDTO>();
            return await Mapper.Map<Task<DriversNumber>, Task<DriversNumberDTO>>(dnUnit.Repository
                .GetAsync(p => p.Id == id));
        }

        public async Task<List<DriversNumberDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<DriversNumber, DriversNumberDTO>();
            return await Mapper.Map<Task<List<DriversNumber>>, Task<List<DriversNumberDTO>>>(dnUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(DriversNumberDTO entity)
        {
            DriversNumber item = MapNewItem(entity);
            dnUnit.Repository.Insert(item);
            return dnUnit.Commit();
        }

        private static DriversNumber MapNewItem(DriversNumberDTO entity)
        {
            CheckForNull(entity);
            var item = new DriversNumber();
            item.DateCreate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(DriversNumberDTO entity)
        {
            DriversNumber item = MapNewItem(entity);
            dnUnit.Repository.Insert(item);
            return await dnUnit.CommitAsync();
        }

        public int Update(DriversNumberDTO entity)
        {
            DriversNumber item = MapEditItem(entity);
            dnUnit.Repository.Update(item);
            return dnUnit.Commit();
        }

        private DriversNumber MapEditItem(DriversNumberDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = dnUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(DriversNumberDTO entity)
        {
            DriversNumber item = MapEditItem(entity);
            dnUnit.Repository.Update(item);
            return await dnUnit.CommitAsync();
        }
    }
}
