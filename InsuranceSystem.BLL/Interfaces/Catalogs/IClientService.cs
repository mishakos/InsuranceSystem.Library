namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    interface IClientService
    {
        Task<List<ClientDTO>> GetByFullNameAsync(string name);
        Task<List<ClientDTO>> GetByITNAsync(string itn);
        Task<List<ClientDTO>> GetByEDRPOU(string edrpou);
        Task<List<ClientDTO>> GetByFactAddressIdAsync(int id);
    }
}
