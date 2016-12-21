namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface ICurrencyService : IService<CurrencyDTO>
    {
        Task<CurrencyDTO> GetByCodeAsync(string code);
    }
}
