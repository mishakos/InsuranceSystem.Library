
namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBankService : IService<BankDTO>
    {
        Task<List<BankDTO>> GetByMFOAsync(string mfo, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByFullNameAsync(string fullName, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByEDRPOUAsync(string edrpou, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByCityAsync(string city, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByAddressAsync(string address, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByPhonesAsync(string phones, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByRateAsync(string rate, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByRateSource(string rateSource, int pageNum, int pageSize);
        Task<List<BankDTO>> GetByParentId(int? id, int pageNum, int pageSize);
        Task<List<BankDTO>> GetPagedAllAsync(int pageNum, int pageSize);

    }
}
