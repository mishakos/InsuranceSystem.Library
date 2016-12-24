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

    public class FraudAttemptService : IFraudAttemptService, IService<FraudAttemptDTO>
    {
        readonly IUnitOfWork<FraudAttempt> faUnit;

        public FraudAttemptService()
        {
            Mapper.CreateMap<FraudAttempt, FraudAttemptDTO>();
            faUnit = new FraudAttemptUnit();
        }

        public int Delete(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            faUnit.Repository.Delete(entity.Id);
            return faUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            faUnit.Repository.Delete((int)id);
            return faUnit.Commit();
        }

        public async Task<int> DeleteAsync(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            faUnit.Repository.Delete(entity.Id);
            return await faUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            faUnit.Repository.Delete((int)id);
            return await faUnit.CommitAsync();
        }

        public void Dispose()
        {
            faUnit.Dispose();
        }

        public IEnumerable<FraudAttemptDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<FraudAttempt>, IEnumerable<FraudAttemptDTO>>(faUnit
                .Repository.GetAll());
        }

        public async Task<List<FraudAttemptDTO>> GetAllAsync()
        {
            return Mapper.Map<List<FraudAttempt>, List<FraudAttemptDTO>>(await faUnit
                .Repository.GetAllAsync());
        }

        public FraudAttemptDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<FraudAttemptDTO>(faUnit.Repository.GetById((int)id));
        }

        public async Task<FraudAttemptDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            
            return Mapper.Map<FraudAttemptDTO>(await faUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<FraudAttemptDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<FraudAttemptDTO>>(await faUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            FraudAttempt item = MapNewItem(entity);
            faUnit.Repository.Insert(item);
            return faUnit.Commit();
        }

        private static FraudAttempt MapNewItem(FraudAttemptDTO entity)
        {
            var item = new FraudAttempt();
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.DateCreate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            FraudAttempt item = MapNewItem(entity);
            faUnit.Repository.Insert(item);
            return await faUnit.CommitAsync();
        }

        public int Update(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = faUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            return faUnit.Commit();
        }

        private void MapExistingItem(FraudAttemptDTO entity, FraudAttempt item)
        {
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            faUnit.Repository.Update(item);
        }

        public async Task<int> UpdateAsync(FraudAttemptDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = faUnit.Repository.GetById(entity.Id);
            MapExistingItem(entity, item);
            return await faUnit.CommitAsync();
        }

    }
}
