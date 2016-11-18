
namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    interface IBankService
    {
        Task<List<BankDTO>> GetByMFOAsync(string mfo);
        Task<List<BankDTO>> GetByFullNameAsync(string fullName);
        Task<List<BankDTO>> GetByEDRPOUAsync(string edrpou);
        Task<List<BankDTO>> GetByCityAsync(string city);
        Task<List<BankDTO>> GetByAddressAsync(string address);
        Task<List<BankDTO>> GetByPhonesAsync(string phones);
        Task<List<BankDTO>> GetByRateAsync(string rate);
        Task<List<BankDTO>> GetByRateSource(string rateSource);
        Task<List<BankDTO>> GetByParentId(int? id);
    }
}
