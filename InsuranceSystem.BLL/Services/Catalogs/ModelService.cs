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
    using System.Threading.Tasks;
    using UnitOfWork;

    public class ModelService : IModelService, IService<ModelDTO>
    {
        readonly IUnitOfWork<Model> mUnit;

        public ModelService()
        {
            mUnit = new ModelUnit();
        }

        public int Delete(ModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(ModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            mUnit.Dispose();
        }

        public IEnumerable<ModelDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<ModelDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ModelDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<ModelDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ModelDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(ModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(ModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(ModelDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(ModelDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
