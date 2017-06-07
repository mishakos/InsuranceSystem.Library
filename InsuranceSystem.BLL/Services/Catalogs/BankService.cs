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
    using System.Linq;

    public class BankService : IBankService
    {
        private IMapper mapper;
        readonly AutoMapperConfig autoMapperConfig;
        readonly IUnitOfWork<Bank> bankUnit;
        public BankService()
        {
            bankUnit = new BankUnit();
            InitializeMapping();
        }

        private void InitializeMapping()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Bank, BankDTO>()
                            .ForMember(dest => dest.ParentName, opt => opt.MapFrom(src => src.Parent.Name))
                            .ReverseMap().ForSourceMember(src => src.Id, opt => opt.Ignore())
                                         .ForSourceMember(src => src.DateCreate, opt => opt.Ignore())
                                         .ForSourceMember(src => src.ModifiedDate, opt => opt.Ignore()));
            mapper = config.CreateMapper();
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
            return MapBankList(bankUnit.Repository.GetAll().ToList());
        }

        public async Task<List<BankDTO>> GetPagedAllAsync(int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedAllAsync(pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByAddressAsync(string address, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.Adress.ToUpper()
                .Contains(address.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByCityAsync(string city, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.City.ToUpper()
                .Contains(city.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByEDRPOUAsync(string edrpou, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.EDRPOU.ToUpper().Contains(edrpou.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByFullNameAsync(string fullName, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.FullName.ToUpper()
                .Contains(fullName.ToUpper()), pageNum, pageSize));
        }

        public BankDTO GetById(int? id)
        {
            CheckForNull(id);
            return mapper.Map<Bank, BankDTO>(bankUnit.Repository.GetById((int)id));
        }

        public async Task<BankDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return mapper.Map<Bank, BankDTO>
                (await bankUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<BankDTO>> GetByMFOAsync(string mfo, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.MFO.ToUpper()
                .Contains(mfo.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByPhonesAsync(string phones, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.Phones.ToUpper()
                .Contains(phones.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByRateAsync(string rate, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.Rate.ToUpper()
                .Contains(rate.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByRateSource(string rateSource, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.RateSource.ToUpper()
                .Contains(rateSource.ToUpper()), pageNum, pageSize));
        }

        public async Task<List<BankDTO>> GetByParentId(int? id, int pageNum = 1, int pageSize = 20)
        {
            CheckForNull(id);
            return MapBankList(await bankUnit.Repository.GetPagedManyAsync(p => p.ParentId == id, pageNum, pageSize));
        }

        public int Insert(BankDTO entity)
        {
            CheckForNull(entity);
            var item = Mapper.Map<BankDTO, Bank>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            bankUnit.Repository.Insert(item);
            return bankUnit.Commit();
        }

        public async Task<int> InsertAsync(BankDTO entity)
        {
            CheckForNull(entity);
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

        public async Task<List<BankDTO>> GetByNameAsync(string name, int pageNum = 1, int pageSize = 20)
        {
            return MapBankList(await bankUnit.Repository
                .GetPagedManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper()), pageNum, pageSize));
        }


        public async Task<List<BankDTO>> GetAllAsync()
        {
            return MapBankList(await bankUnit.Repository.GetAllAsync());
        }

        private List<BankDTO> MapBankList(List<Bank> items)
        {
            return mapper.Map<List<Bank>, List<BankDTO>>(items);
        }

        public Task<List<BankDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
