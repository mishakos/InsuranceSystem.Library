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

    public class BankService : IBankService, IService<BankDTO>
    {
        readonly IUnitOfWork<Bank> bankUnit;
        public BankService()
        {
            bankUnit = new BankUnit();
        }

        public int Delete(BankDTO entity)
        {
            CheckForNull(entity);
            bankUnit.Repository.Delete(entity.Id);
            return bankUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            bankUnit.Repository.Delete((int)id);
            return bankUnit.Commit();
        }

        public async Task<int> DeleteAsync(BankDTO entity)
        {
            CheckForNull(entity);
            bankUnit.Repository.Delete(entity.Id);
            return await bankUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            bankUnit.Repository.Delete((int)id);
            return await bankUnit.CommitAsync();
        }

        public void Dispose()
        {
            bankUnit.Dispose();
        }

        public IEnumerable<BankDTO> GetAll()
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return Mapper.Map<IEnumerable<Bank>, IEnumerable<BankDTO>>(
                bankUnit.Repository.GetAll());
        }

        public async Task<List<BankDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>,
                Task<List<BankDTO>>>(bankUnit.Repository.GetAllAsync());
        }

        public async Task<List<BankDTO>> GetByAddressAsync(string address)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.Adress.ToUpper()
                .Contains(address.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByCityAsync(string city)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.City.ToUpper()
                .Contains(city.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByEDRPOUAsync(string edrpou)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.EDRPOU.ToUpper().Contains(edrpou.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByFullNameAsync(string fullName)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.FullName.ToUpper()
                .Contains(fullName.ToUpper())));
        }

        public BankDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Bank, BankDTO>();
            return Mapper.Map<Bank, BankDTO>(bankUnit.Repository.GetById((int)id));
        }

        public async Task<BankDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<Bank>, Task<BankDTO>>
                (bankUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BankDTO>> GetByMFOAsync(string mfo)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.MFO.ToUpper()
                .Contains(mfo.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByPhonesAsync(string phones)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.Phones.ToUpper()
                .Contains(phones.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByRateAsync(string rate)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.Rate.ToUpper()
                .Contains(rate.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByRateSource(string rateSource)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.RateSource.ToUpper()
                .Contains(rateSource.ToUpper())));
        }

        public async Task<List<BankDTO>> GetByParentId(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>
                (bankUnit.Repository.GetManyAsync(p => p.ParentId == id));
        }

        public int Insert(BankDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BankDTO, Bank>();
            var item = Mapper.Map<BankDTO, Bank>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            bankUnit.Repository.Insert(item);
            return bankUnit.Commit();
        }

        public async Task<int> InsertAsync(BankDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<BankDTO, Bank>();
            var item = Mapper.Map<BankDTO, Bank>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            bankUnit.Repository.Insert(item);
            return await bankUnit.CommitAsync();
        }

        public int Update(BankDTO entity)
        {
            CheckForNull(entity);
            Bank item = FillBank(entity);
            bankUnit.Repository.Insert(item);
            return bankUnit.Commit();
        }

        private Bank FillBank(BankDTO entity)
        {
            var item = bankUnit.Repository.GetById(entity.Id);
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.MFO = entity.MFO;
            item.Adress = entity.Address;
            item.City = entity.City;
            item.CorrespondingAccount = entity.CorrespondingAccount;
            item.EDRPOU = entity.EDRPOU;
            item.FullName = entity.FullName;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            item.Phones = entity.Phones;
            item.Rate = entity.Rate;
            item.RateSource = entity.RateSource;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public async Task<int> UpdateAsync(BankDTO entity)
        {
            CheckForNull(entity);
            Bank item = FillBank(entity);
            bankUnit.Repository.Insert(item);
            return await bankUnit.CommitAsync();
        }

        public async Task<List<BankDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Bank, BankDTO>();
            return await Mapper.Map<Task<List<Bank>>, Task<List<BankDTO>>>(bankUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }
    }
}
