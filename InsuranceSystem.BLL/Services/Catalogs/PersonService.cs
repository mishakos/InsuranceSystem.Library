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

    public class PersonService : IPersonService
    {
        readonly IUnitOfWork<Person> personUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public PersonService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            personUnit = new PersonUnit();
        }

        public int Delete(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            personUnit.Dispose();
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public PersonDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PersonDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Update(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PersonDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
