using System;

namespace InsuranceSystem.MVC.Models.Catalogs
{
    public class BankAccountModel : CatalogModel
    {
        public int CurrencyId { get; set; }
        public string AccountNumber { get; set; }
        public int BankId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string PurposeOfPayment { get; set; }

    }
}
