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

    public class ClientService : IClientService, IService<ClientDTO>
    {
        readonly IUnitOfWork<Client> clientUnit;

        public ClientService()
        {
            clientUnit = new ClientUnit();
        }

        public int Delete(ClientDTO entity)
        {
            CheckForNull(entity);
            clientUnit.Repository.Delete(entity.Id);
            return clientUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            clientUnit.Repository.Delete((int)id);
            return clientUnit.Commit();
        }

        public async Task<int> DeleteAsync(ClientDTO entity)
        {
            CheckForNull(entity);
            clientUnit.Repository.Delete(entity.Id);
            return await clientUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            clientUnit.Repository.Delete((int)id);
            return await clientUnit.CommitAsync();
        }

        public void Dispose()
        {
            clientUnit.Dispose();
        }

        public IEnumerable<ClientDTO> GetAll()
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return Mapper.Map<IEnumerable<Client>, IEnumerable<ClientDTO>>(clientUnit
                .Repository.GetAll());
        }

        public async Task<List<ClientDTO>> GetAllAsync()
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetAllAsync());
        }

        public async Task<List<ClientDTO>> GetByEDRPOU(string edrpou)
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetManyAsync(p => p.EDRPOU.ToUpper().Contains(edrpou.ToUpper())));
        }

        public async Task<List<ClientDTO>> GetByFactAddressIdAsync(int id)
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetManyAsync(p => p.FactAdressId == id));
        }

        public async Task<List<ClientDTO>> GetByFullNameAsync(string name)
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetManyAsync(p => p.FullName.ToUpper().Contains(name.ToUpper())));
        }

        public ClientDTO GetById(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Client, ClientDTO>();
            return Mapper.Map<Client, ClientDTO>(clientUnit.Repository.GetById((int)id));
        }

        public async Task<ClientDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<Client>, Task<ClientDTO>>(clientUnit
                .Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<ClientDTO>> GetByITNAsync(string itn)
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetManyAsync(p => p.ITN.ToUpper().Contains(itn.ToUpper())));
        }

        public async Task<List<ClientDTO>> GetByNameAsync(string name)
        {
            Mapper.CreateMap<Client, ClientDTO>();
            return await Mapper.Map<Task<List<Client>>, Task<List<ClientDTO>>>(clientUnit
                .Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(ClientDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<ClientDTO, Client>();
            var item = Mapper.Map<ClientDTO, Client>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            clientUnit.Repository.Insert(item);
            return clientUnit.Commit();
        }

        public async Task<int> InsertAsync(ClientDTO entity)
        {
            CheckForNull(entity);
            Mapper.CreateMap<ClientDTO, Client>();
            var item = Mapper.Map<ClientDTO, Client>(entity);
            item.DateCreate = DateTime.Now;
            item.ModifiedDate = DateTime.Now;
            clientUnit.Repository.Insert(item);
            return await clientUnit.CommitAsync();
        }

        public int Update(ClientDTO entity)
        {
            Client item = FillItem(entity);
            clientUnit.Repository.Update(item);
            return clientUnit.Commit();
        }

        private Client FillItem(ClientDTO entity)
        {
            CheckForNull(entity);
            var item = clientUnit.Repository.GetById(entity.Id);
            CheckForNull(item);
            item.ModifiedDate = DateTime.Now;
            item.BancAccountId = entity.BancAccountId;
            item.EDRPOU = entity.EDRPOU;
            item.FactAdressId = entity.FactAddressId;
            item.FullName = entity.FullName;
            item.IsDelete = entity.IsDelete;
            item.IsGroup = entity.IsGroup;
            item.ITN = entity.ITN;
            item.LegalAdressId = entity.LegalAddressId;
            item.Name = entity.Name;
            item.ParentId = entity.ParentId;
            return item;
        }

        public async Task<int> UpdateAsync(ClientDTO entity)
        {
            Client item = FillItem(entity);
            clientUnit.Repository.Update(item);
            return await clientUnit.CommitAsync();
        }
    }
}
