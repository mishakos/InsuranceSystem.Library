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

    /// <summary>
    /// Service to manage address catalog
    /// </summary>
    public class AddressService : IAddressService
    {
        readonly AutoMapperConfig autoMapperConfig;
        /// <summary>
        /// address unit to connect to data layer
        /// </summary>
        readonly IUnitOfWork<Address> addressUnit;
        public AddressService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            addressUnit = new AddressUnit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddressDTO> GetAll()
        {
            Mapper.CreateMap<Address, AddressDTO>();
            return Mapper.Map<IEnumerable<Address>,
                List<AddressDTO>>(addressUnit.Repository.GetAll());
        }

        public AddressDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Address, AddressDTO>();
            return Mapper.Map<Address, AddressDTO>(addressUnit
                .Repository.GetById((int)id));
        }

        public int Insert(AddressDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            Mapper.CreateMap<AddressDTO, Address>();
            var item = Mapper.Map<AddressDTO, Address>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            addressUnit.Repository.Insert(item);
            return addressUnit.Commit();
        }

        public int Update(AddressDTO entity)
        {
            CheckForNull(entity);
            Address item = FillAddressParameters(entity);
            addressUnit.Repository.Update(item);
            return addressUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            addressUnit.Repository.Delete((int)id);
            return addressUnit.Commit();
        }

        public int Delete(AddressDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<AddressDTO, Address>();
            addressUnit.Repository.Delete(Mapper.Map<AddressDTO, Address>(entity));
            return addressUnit.Commit();
        }

        public async Task<List<AddressDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository.GetAllAsync());
        }

        public async Task<AddressDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Task<Address>, Task<AddressDTO>>();
            return await Mapper.Map<Task<Address>, Task<AddressDTO>>(addressUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<int> InsertAsync(AddressDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<AddressDTO, Address>();
            var item = Mapper.Map<AddressDTO, Address>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            addressUnit.Repository.Insert(item);
            return await addressUnit.CommitAsync();
        }

        public async Task<int> UpdateAsync(AddressDTO entity)
        {
            CheckForNull(entity);
            Address item = FillAddressParameters(entity);

            addressUnit.Repository.Update(item);
            return await addressUnit.CommitAsync();
        }

        private Address FillAddressParameters(AddressDTO entity)
        {
            var item = addressUnit.Repository.GetById(entity.Id);
            item.IsDelete = entity.IsDelete;
            item.Name = entity.Name;
            item.FirstLineAddress = entity.FirstLineAdress;
            item.SecondLineAddress = entity.SecondLineAdress;
            item.County = entity.County;
            item.City = entity.City;
            item.Country = entity.Country;
            item.ParentId = entity.ParentId;
            item.State = entity.State;
            item.Zip = entity.Zip;
            item.ModifiedDate = DateTime.Now;
            return item;
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            addressUnit.Repository.Delete((int)id);
            return await addressUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(AddressDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<AddressDTO, Address>();
            addressUnit.Repository.Delete(Mapper.Map<AddressDTO, Address>(entity));
            return await addressUnit.CommitAsync();
        }

        public async Task<List<AddressDTO>> GetByFirstLineAsync(string firstLine)
        {
            CheckForNull(firstLine);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.FirstLineAddress.ToUpper().Contains(firstLine.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetBySecondLineAsync(string secondLine)
        {
            CheckForNull(secondLine);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.SecondLineAddress.ToUpper().Contains(secondLine.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetByCountyAsync(string county)
        {
            CheckForNull(county);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.County.ToUpper().Contains(county.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetByCountryAsync(string country)
        {
            CheckForNull(country);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.Country.ToUpper().Contains(country.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetByCityAsync(string city)
        {
            CheckForNull(city);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.City.ToUpper().Contains(city.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetByStateAsync(string state)
        {
            CheckForNull(state);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.State.ToUpper().Contains(state.ToUpper())));
        }

        public async Task<List<AddressDTO>> GetByZipAsync(string zip)
        {
            CheckForNull(zip);
            Mapper.CreateMap<Task<List<Address>>, Task<List<AddressDTO>>>();
            return await Mapper.Map<Task<List<Address>>,
                Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.Zip.ToUpper().Contains(zip.ToUpper())));
        }

        public void Dispose()
        {
            addressUnit.Dispose();
        }

        public async Task<List<AddressDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Address, AddressDTO>();
            return await Mapper.Map<Task<List<Address>>, Task<List<AddressDTO>>>(addressUnit.Repository
                .GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }
    }
}
