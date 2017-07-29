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
    using InsuranceSystem.BLL.Infrastructure;

    public class BonusMalusService : IBonusMalusService
    {
        readonly IUnitOfWork<BonusMalus> bonusMalusUnit;
        readonly AutoMapperConfig autoMapperConfig;
        public BonusMalusService()
        {
            bonusMalusUnit = new BonusMalusUnit();
            autoMapperConfig = AutoMapperConfig.Instance;
        }

        public int Delete(BonusMalusDTO entity)
        {
            CheckForNull(entity);
            bonusMalusUnit.Repository.Delete(entity.Id);
            return bonusMalusUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            bonusMalusUnit.Repository.Delete((int)id);
            return bonusMalusUnit.Commit();
        }

        public async Task<int> DeleteAsync(BonusMalusDTO entity)
        {
            CheckForNull(entity);
            bonusMalusUnit.Repository.Delete(entity.Id);
            return await bonusMalusUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            bonusMalusUnit.Repository.Delete((int)id);
            return await bonusMalusUnit.CommitAsync();
        }

        public void Dispose()
        {
            bonusMalusUnit.Dispose();
        }

        public IEnumerable<BonusMalusDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<BonusMalus>, IEnumerable<BonusMalusDTO>>
                (bonusMalusUnit.Repository.GetAll());
        }

        public async Task<List<BonusMalusDTO>> GetAllAsync()
        {
            return Mapper.Map<List<BonusMalus>, List<BonusMalusDTO>>
                (await bonusMalusUnit.Repository.GetAllAsync());
        }

        public BonusMalusDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<BonusMalus, BonusMalusDTO>(bonusMalusUnit
                .Repository.GetById((int)id));
        }

        public async Task<BonusMalusDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<BonusMalus, BonusMalusDTO>
                (await bonusMalusUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BonusMalusDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<BonusMalus>, List<BonusMalusDTO>>
                (await bonusMalusUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(BonusMalusDTO entity)
        {
            CheckForNull(entity);
            var item = Mapper.Map<BonusMalusDTO, BonusMalus>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            bonusMalusUnit.Repository.Insert(item);
            return bonusMalusUnit.Commit();
        }

        public async Task<int> InsertAsync(BonusMalusDTO entity)
        {
            CheckForNull(entity);
            var item = Mapper.Map<BonusMalusDTO, BonusMalus>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            bonusMalusUnit.Repository.Insert(item);
            return await bonusMalusUnit.CommitAsync();
        }

        public int Update(BonusMalusDTO entity)
        {
            BonusMalus item = FillBonusMalus(entity);
            bonusMalusUnit.Repository.Insert(item);
            return bonusMalusUnit.Commit();
        }

        private BonusMalus FillBonusMalus(BonusMalusDTO entity)
        {
            CheckForNull(entity);
            var item = bonusMalusUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(BonusMalusDTO entity)
        {
            BonusMalus item = FillBonusMalus(entity);
            bonusMalusUnit.Repository.Insert(item);
            return await bonusMalusUnit.CommitAsync();
        }
    }
}
