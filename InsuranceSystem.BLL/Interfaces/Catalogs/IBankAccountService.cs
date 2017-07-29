namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTO.Catalogs;

    public interface IBankAccountService : IService<BankAccountDTO>
    {
        Task<List<BankAccountDTO>> GetByCurrencyIdAsync(int? id);
        Task<List<BankAccountDTO>> GetByAccountNumberAsync(string id);
        Task<List<BankAccountDTO>> GetByBankIdAsync(int? id);
        Task<List<BankAccountDTO>> GetByOpenDate(DateTime date);
        Task<List<BankAccountDTO>> GetByCloseDate(DateTime date);

    }
}
