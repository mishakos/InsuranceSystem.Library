namespace InsuranceSystem.BLL.Services.Documents
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Documents;
    using Library.Models.Documents;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Documents;
    using DTO.Documents;
    using static Validation.CheckValues;
    using Interfaces;
    using System.Threading.Tasks;
    using UnitOfWork;

    public class MTPLPolicyService : IMTPLPolicyService, IService<MTPLPolicyDTO>
    {
        readonly IUnitOfWork<MTPLPolicy> mtplUnit;

        public MTPLPolicyService()
        {
            mtplUnit = new MTPLPolicyUnit();
        }

        public int Delete(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            mtplUnit.Dispose();
        }

        public IEnumerable<MTPLPolicyDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<MTPLPolicyDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public MTPLPolicyDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<MTPLPolicyDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MTPLPolicyDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MTPLPolicyDTO> GetMTPLPolicies()
        {
            throw new NotImplementedException();
        }

        public MTPLPolicyDTO GetMTPLPolicy(int? id)
        {
            throw new NotImplementedException();
        }

        public void HoldMTPLPolicy(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public void MakeMTPLPolicy(MTPLPolicyDTO mtplPolicyDTO)
        {
            throw new NotImplementedException();
        }

        public void SetDeleteMTPLPolicyDTO(int? id)
        {
            throw new NotImplementedException();
        }

        public void UnHoldMTPLPolicyDTO(int? id)
        {
            throw new NotImplementedException();
        }

        public int Update(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MTPLPolicyDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMTPLPolicy(MTPLPolicyDTO mtplPolicyDTO)
        {
            throw new NotImplementedException();
        }
    }
}
