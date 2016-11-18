namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Library.Models.Enums;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Catalogs;
    using static Validation.CheckValues;
    using UnitOfWork;
    using Interfaces;
    using System.Threading.Tasks;

    public class FirmService : IFirmService, IService<FirmDTO>
    {
        readonly IUnitOfWork<Firm> firmUnit;

        public FirmService()
        {
            firmUnit = new FirmUnit();
        }

        public int Delete(FirmDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            firmUnit.Repository.Delete(entity.Id);
            return firmUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            firmUnit.Repository.Delete((int)id);
            return firmUnit.Commit();
        }

        public async Task<int> DeleteAsync(FirmDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            firmUnit.Repository.Delete(entity.Id);
            return await firmUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            firmUnit.Repository.Delete((int)id);
            return await firmUnit.CommitAsync();
        }

        public void Dispose()
        {
            firmUnit.Dispose();
        }

        public IEnumerable<FirmDTO> GetAll()
        {
            Mapper.CreateMap<Firm, FirmDTO>();
            return Mapper.Map<IEnumerable<Firm>, IEnumerable<FirmDTO>>(firmUnit.Repository.GetAll());
        }

        public async Task<List<FirmDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Firm, FirmDTO>();
            return await Mapper.Map<Task<List<Firm>>, Task<List<FirmDTO>>>(firmUnit.Repository.GetAllAsync());
        }

        public async Task<List<FirmDTO>> GetByEDRPOUAsync(string edrpou)
        {
            Mapper.CreateMap<Firm, FirmDTO>();
            return await Mapper.Map<Task<List<Firm>>, Task<List<FirmDTO>>>(firmUnit.Repository
                .GetManyAsync(p => p.EDRPOU.ToUpper().Contains(edrpou.ToUpper())));
        }

        public FirmDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Firm, FirmDTO>();
            return Mapper.Map<Firm, FirmDTO>(firmUnit.Repository.GetById((int)id));
        }

        public async Task<FirmDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Firm, FirmDTO>();
            return await Mapper.Map<Task<Firm>, Task<FirmDTO>>(firmUnit.Repository
                .GetAsync(p => p.Id == id));
        }

        public async Task<List<FirmDTO>> GetByNameAsync(string name)
        {
            CheckForNull(name);
            Mapper.CreateMap<Firm, FirmDTO>();
            return await Mapper.Map<Task<List<Firm>>, Task<List<FirmDTO>>>(firmUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(FirmDTO entity)
        {
            Firm item = FillNewFirm(entity);
            firmUnit.Repository.Insert(item);
            return firmUnit.Commit();


        }

        private static Firm FillNewFirm(FirmDTO entity)
        {
            var item = new Firm();
            item.BankAccountId = entity.BankAccountId;
            item.DateCreate = DateTime.Now;
            item.FactAdressId = entity.FactAdressId;
            item.FullName = entity.FullName;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.LegalAdressId = entity.LegalAdressId;
            item.LegalType = (LegalType)entity.LegalType;
            item.ModifiedDate = DateTime.Now;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> InsertAsync(FirmDTO entity)
        {
            Firm item = FillNewFirm(entity);
            firmUnit.Repository.Insert(item);
            return await firmUnit.CommitAsync();
        }

        public int Update(FirmDTO entity)
        {
            Firm item = UpdateFirmInfo(entity);
            firmUnit.Repository.Update(item);
            return firmUnit.Commit();

        }

        private Firm UpdateFirmInfo(FirmDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            var item = firmUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.ModifiedDate = DateTime.Now;
            item.BankAccountId = entity.BankAccountId;
            item.EDRPOU = entity.EDRPOU;
            item.FactAdressId = entity.FactAdressId;
            item.FullName = entity.FullName;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.LegalAdressId = entity.LegalAdressId;
            item.LegalType = (LegalType)entity.LegalType;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(FirmDTO entity)
        {
            Firm item = UpdateFirmInfo(entity);
            firmUnit.Repository.Update(item);
            return await firmUnit.CommitAsync();
        }

    }
}
