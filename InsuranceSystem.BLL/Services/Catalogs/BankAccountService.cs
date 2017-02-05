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

    public class BankAccountService : IBankAccountService
    {
        readonly AutoMapperConfig autoMapperConfig;
        readonly IUnitOfWork<BankAccount> bankAccountUnit;
        public BankAccountService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            bankAccountUnit = new BankAccountUnit();
        }

        public int Delete(BankAccountDTO entity)
        {
            CheckForNull(entity);
            bankAccountUnit.Repository.Delete(entity.Id);
            return bankAccountUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            bankAccountUnit.Repository.Delete((int)id);
            return bankAccountUnit.Commit();
        }

        public async Task<int> DeleteAsync(BankAccountDTO entity)
        {
            CheckForNull(entity);
            bankAccountUnit.Repository.Delete(entity.Id);
            return await bankAccountUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            bankAccountUnit.Repository.Delete((int)id);
            return await bankAccountUnit.CommitAsync();
        }

        public void Dispose()
        {
            bankAccountUnit.Dispose();
        }

        public IEnumerable<BankAccountDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<BankAccount>, IEnumerable<BankAccountDTO>>(
                bankAccountUnit.Repository.GetAll());
        }

        public async Task<List<BankAccountDTO>> GetAllAsync()
        {
            return  Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await
                bankAccountUnit.Repository.GetAllAsync());
        }

        public async Task<List<BankAccountDTO>> GetByAccountNumberAsync(string number)
        {
           return  Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await
                bankAccountUnit.Repository.GetManyAsync(p => p.AccountNumber.Trim() == number));
        }

        public async Task<List<BankAccountDTO>> GetByBankIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await 
                bankAccountUnit.Repository.GetManyAsync(p => p.BankId == (int)id));
        }

        public async Task<List<BankAccountDTO>> GetByCloseDate(DateTime date)
        {
            CheckForNull(date);
            return  Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await
                bankAccountUnit.Repository.GetManyAsync(p => p.CloseDate == date));
        }

        public async Task<List<BankAccountDTO>> GetByCurrencyIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await
                bankAccountUnit.Repository.GetManyAsync(p => p.CurrencyId == (int)id));
        }

        public BankAccountDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<BankAccount, BankAccountDTO>(
                bankAccountUnit.Repository.GetById((int)id));
        }

        public async Task<BankAccountDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return  Mapper.Map<BankAccount, BankAccountDTO>(await
                bankAccountUnit.Repository.GetAsync(p => p.Id == id));

        }

        public async Task<List<BankAccountDTO>> GetByOpenDate(DateTime date)
        {
            CheckForNull(date);
            return  Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await
                bankAccountUnit.Repository.GetManyAsync(p => p.OpenDate == date));

        }

        public int Insert(BankAccountDTO entity)
        {
            CheckForNull(entity);
            bankAccountUnit.Repository.Insert(Mapper.Map<BankAccountDTO, BankAccount>(entity));
            return bankAccountUnit.Commit();
        }

        public async Task<int> InsertAsync(BankAccountDTO entity)
        {
            CheckForNull(entity);
            bankAccountUnit.Repository.Insert(Mapper.Map<BankAccountDTO, BankAccount>(entity));
            return await bankAccountUnit.CommitAsync();
        }

        public int Update(BankAccountDTO entity)
        {
            CheckForNull(entity);
            BankAccount item = FillBankAccount(entity);
            bankAccountUnit.Repository.Insert(item);
            return bankAccountUnit.Commit();
        }

        private BankAccount FillBankAccount(BankAccountDTO entity)
        {
            var item = bankAccountUnit.Repository.GetById(entity.Id);
            item.ModifiedDate = DateTime.Now;
            item.AccountNumber = entity.AccountNumber;
            item.BankId = entity.BankId;
            item.CloseDate = entity.CloseDate;
            item.CurrencyId = entity.CurrencyId;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.OpenDate = entity.OpenDate;
            item.ParentId = entity.ParentId;
            item.PurposeOfPayment = entity.PurposeOfPayment;
            return item;
        }

        public async Task<int> UpdateAsync(BankAccountDTO entity)
        {
            CheckForNull(entity);
            BankAccount item = FillBankAccount(entity);
            bankAccountUnit.Repository.Insert(item);
            return await bankAccountUnit.CommitAsync();
        }

        public async Task<List<BankAccountDTO>> GetByNameAsync(string name)
        {
            return  Mapper.Map<List<BankAccount>, List<BankAccountDTO>>(await bankAccountUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }
    }
}
