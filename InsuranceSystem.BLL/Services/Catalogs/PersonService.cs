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
            CheckForNull(entity);
            CheckForNull(entity.Id);
            personUnit.Repository.Delete(entity.Id);
            return personUnit.Commit();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(PersonDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            personUnit.Repository.Delete((int)id);
            return await personUnit.CommitAsync();
        }

        public void Dispose()
        {
            personUnit.Dispose();
        }

        public IEnumerable<PersonDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(personUnit.Repository.GetAll());
        }

        public async Task<List<PersonDTO>> GetAllAsync()
        {
            return Mapper.Map<IEnumerable<Person>, List<PersonDTO>>(await personUnit.Repository.GetAllAsync());
        }

        public PersonDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Person, PersonDTO>(personUnit.Repository.GetById((int)id));
        }

        public async Task<PersonDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<Person, PersonDTO>(await personUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<PersonDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<Person>, List<PersonDTO>>(await personUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(PersonDTO entity)
        {
            var model = Mapper.Map<PersonDTO, Person>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            personUnit.Repository.Insert(model);
            return personUnit.Commit();
        }

        public async Task<int> InsertAsync(PersonDTO entity)
        {
            var model = Mapper.Map<PersonDTO, Person>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            personUnit.Repository.Insert(model);
            return await personUnit.CommitAsync();
        }

        public int Update(PersonDTO entity)
        {
            var model = personUnit.Repository.GetById(entity.Id);
            MapPerson(entity, model);
            personUnit.Repository.Update(model);
            return personUnit.Commit();
        }

        private void MapPerson(PersonDTO entity, Person model)
        {
            model.AddressId = entity.AdressId;
            model.Birthdate = entity.BirthDate;
            model.CodeDRFO = entity.CodeDRFO;
            model.DocumentDate = entity.DocumentDate;
            model.DocumentSeries = entity.DocumentSeries;
            model.DocumentIssuer = entity.DocumentWhoGive;
            model.DocumentType = entity.DocumentType;
            model.DocumentNumber = entity.DocumentNumber;
            model.EMail = entity.EMail;
            model.FirstName = entity.FirstName;
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.LastName = entity.LastName;
            model.MiddleName = entity.MiddleName;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(PersonDTO entity)
        {
            var model = await personUnit.Repository.GetAsync(p => p.Id == entity.Id);
            MapPerson(entity, model);
            personUnit.Repository.Update(model);
            return await personUnit.CommitAsync();
        }
    }
}
