namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;
    using Interfaces;
    using UnitOfWork;
    using System.Threading.Tasks;

    public class StatusService : IStatusService
    {
        readonly IUnitOfWork<Status> statusUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public StatusService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            statusUnit = new StatusUnit();
        }

        public int Delete(StatusDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            statusUnit.Repository.Delete(entity.Id);
            return statusUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            statusUnit.Repository.Delete((int)id);
            return statusUnit.Commit();
        }

        public async Task<int> DeleteAsync(StatusDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            statusUnit.Repository.Delete(entity.Id);
            return await statusUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            statusUnit.Repository.Delete((int)id);
            return await statusUnit.CommitAsync();
        }

        public void Dispose()
        {
            statusUnit.Dispose();
        }

        public IEnumerable<StatusDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Status>, List<StatusDTO>>(statusUnit.Repository.GetAll());
        }

        public async Task<List<StatusDTO>> GetAllAsync()
        {
            return Mapper.Map<List<Status>, List<StatusDTO>>(await statusUnit.Repository.GetAllAsync());
        }

        public StatusDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Status, StatusDTO>(statusUnit.Repository.GetById((int)id));
        }

        public async Task<StatusDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Status, StatusDTO>(await statusUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<StatusDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<Status>, List<StatusDTO>>(await statusUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(StatusDTO entity)
        {
            var model = Mapper.Map<StatusDTO, Status>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            statusUnit.Repository.Insert(model);
            return statusUnit.Commit();
        }

        public async Task<int> InsertAsync(StatusDTO entity)
        {
            var model = Mapper.Map<StatusDTO, Status>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            statusUnit.Repository.Insert(model);
            return await  statusUnit.CommitAsync();
        }

        public int Update(StatusDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var model = statusUnit.Repository.GetById(entity.Id);
            MapStatus(entity, model);
            statusUnit.Repository.Update(model);
            return statusUnit.Commit();
        }

        private static void MapStatus(StatusDTO entity, Status model)
        {
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
        }

        public async  Task<int> UpdateAsync(StatusDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var model = await statusUnit.Repository.GetAsync(p=> p.Id == entity.Id);
            MapStatus(entity, model);
            statusUnit.Repository.Update(model);
            return await statusUnit.CommitAsync();
        }
    }
}
