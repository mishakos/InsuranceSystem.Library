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
    public class CurrencyService : ICurrencyService
    {
        readonly IUnitOfWork<Currency> currencyUnit;

        public CurrencyService()
        {
            currencyUnit = new CurrencyUnit();
        }

        public int Delete(CurrencyDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            currencyUnit.Repository.Delete(entity.Id);
            return currencyUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            currencyUnit.Repository.Delete((int)id);
            return currencyUnit.Commit();
        }

        public async Task<int> DeleteAsync(CurrencyDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            currencyUnit.Repository.Delete(entity.Id);
            return await currencyUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            currencyUnit.Repository.Delete((int)id);
            return await currencyUnit.CommitAsync();
        }

        public void Dispose()
        {
            currencyUnit.Dispose();
        }

        public IEnumerable<CurrencyDTO> GetAll()
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<IEnumerable<Currency>, IEnumerable<CurrencyDTO>>(currencyUnit
                .Repository.GetAll());
        }

        public async Task<List<CurrencyDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<List<Currency>, List<CurrencyDTO>>(
                await currencyUnit.Repository.GetAllAsync());
        }

        public async Task<CurrencyDTO> GetByCodeAsync(string code)
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<Currency, CurrencyDTO>(await currencyUnit.Repository
                .GetAsync(p => p.Code.ToUpper().Contains(code.ToUpper())));
        }

        public CurrencyDTO GetById(int? id)
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<Currency, CurrencyDTO>(currencyUnit.Repository
                .GetById((int)id));
        }

        public async Task<CurrencyDTO> GetByIdAsync(int? id)
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<Currency, CurrencyDTO>(await currencyUnit.Repository
                .GetAsync(p => p.Id == id));
        }

        public async Task<List<CurrencyDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Currency, CurrencyDTO>();
            return Mapper.Map<List<Currency>, List<CurrencyDTO>>(await 
                currencyUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(CurrencyDTO entity)
        {
            CheckForNull(entity);
            Currency item = FillNewCurrency(entity);
            currencyUnit.Repository.Insert(item);
            return currencyUnit.Commit();
        }

        private static Currency FillNewCurrency(CurrencyDTO entity)
        {
            var item = new Currency();
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParametresForInWords = entity.ParametresForInWords;
            item.ParentId = entity.ParentId;
            item.Code = entity.Code;
            item.FullName = entity.FullName;
            return item;
        }

        public async Task<int> InsertAsync(CurrencyDTO entity)
        {
            CheckForNull(entity);
            var item = FillNewCurrency(entity);
            currencyUnit.Repository.Insert(item);
            return await currencyUnit.CommitAsync();
        }

        public int Update(CurrencyDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = currencyUnit.Repository.GetById(entity.Id);
            UpdateCurrency(entity, item);
            currencyUnit.Repository.Update(item);
            return currencyUnit.Commit();
        }

        private static void UpdateCurrency(CurrencyDTO entity, Currency item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Code = entity.Code;
            item.FullName = entity.FullName;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParametresForInWords = entity.ParametresForInWords;
            item.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(CurrencyDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = currencyUnit.Repository.GetById(entity.Id);
            UpdateCurrency(entity, item);
            currencyUnit.Repository.Update(item);
            return await currencyUnit.CommitAsync();
        }
    }
}
