using System;

namespace InsuranceSystem.BLL.DTO.Catalogs
{
    public class BankAccountDTO : CatalogDTO
    {
        public int CurrencyId { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string PurposeOfPayment { get; set; }

    }
}
