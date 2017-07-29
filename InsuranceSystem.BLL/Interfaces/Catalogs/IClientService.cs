namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IClientService : IService<ClientDTO>
    {
        Task<List<ClientDTO>> GetByFullNameAsync(string name);
        Task<List<ClientDTO>> GetByITNAsync(string itn);
        Task<List<ClientDTO>> GetByEDRPOU(string edrpou);
        Task<List<ClientDTO>> GetByFactAddressIdAsync(int id);
    }
}
