namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    interface ICurrencyService
    {
        Task<CurrencyDTO> GetByCodeAsync(string code);
    }
}
