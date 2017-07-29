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

    public class ContractTermService : IContractTermService
    {
        readonly IUnitOfWork<ContractTerm> contractTermUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public ContractTermService()
        {
            contractTermUnit = new ContractTermUnit();
            autoMapperConfig = AutoMapperConfig.Instance;
        }

        public int Delete(ContractTermDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            contractTermUnit.Repository.Delete(entity.Id);
            return contractTermUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            contractTermUnit.Repository.Delete((int)id);
            return contractTermUnit.Commit();
        }

        public async Task<int> DeleteAsync(ContractTermDTO entity)
        {
            CheckForNull(entity);
            contractTermUnit.Repository.Delete(entity.Id);
            return await contractTermUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            contractTermUnit.Repository.Delete((int)id);
            return await contractTermUnit.CommitAsync();
        }

        public void Dispose()
        {
            contractTermUnit.Dispose();
        }

        public IEnumerable<ContractTermDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<ContractTerm>, IEnumerable<ContractTermDTO>>(
                contractTermUnit.Repository.GetAll());
        }

        public async Task<List<ContractTermDTO>> GetAllAsync()
        {
            return Mapper.Map<List<ContractTerm>, List<ContractTermDTO>>
                (await contractTermUnit.Repository.GetAllAsync());
        }

        public ContractTermDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<ContractTerm, ContractTermDTO>(contractTermUnit
                .Repository.GetById((int)id));

        }

        public async Task<ContractTermDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<ContractTerm, ContractTermDTO>(await contractTermUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<ContractTermDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<ContractTerm>, List<ContractTermDTO>>(await
                contractTermUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));

        }

        public int Insert(ContractTermDTO entity)
        {
            CheckForNull(entity);
            var item = Mapper.Map<ContractTermDTO, ContractTerm>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            contractTermUnit.Repository.Insert(item);
            return contractTermUnit.Commit();
        }

        public async Task<int> InsertAsync(ContractTermDTO entity)
        {
            CheckForNull(entity);
            var item = Mapper.Map<ContractTermDTO, ContractTerm>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            contractTermUnit.Repository.Insert(item);
            return await contractTermUnit.CommitAsync();
        }

        public int Update(ContractTermDTO entity)
        {
            ContractTerm item = FillItem(entity);
            contractTermUnit.Repository.Update(item);
            return contractTermUnit.Commit();
        }

        private ContractTerm FillItem(ContractTermDTO entity)
        {
            CheckForNull(entity);
            var item = contractTermUnit.Repository.GetById(entity.Id);
            item.ModifiedDate = DateTime.Now;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(ContractTermDTO entity)
        {
            ContractTerm item = FillItem(entity);
            contractTermUnit.Repository.Update(item);
            return await contractTermUnit.CommitAsync();
        }
    }
}
