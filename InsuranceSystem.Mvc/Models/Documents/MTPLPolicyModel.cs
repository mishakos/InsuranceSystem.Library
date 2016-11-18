
namespace InsuranceSystem.MVC.Models.Documents
{
    using System;

    public class MTPLPolicyModel : DocumentModel
    {
        public int PolicyId { get; set; }

        public int StickerId { get; set; }

        public int ClientId { get; set; }

        public int BeneficiaryClientId { get; set; }

        public int BeneficiaryBankId { get; set; }

        public int FirmId { get; set; }

        public int DepartmentId { get; set; }

        public int SalesOfficeId { get; set; }

        public int InsuranceProductId { get; set; }
        
        public int InsuranceTypeId { get; set; }
        
        public int VehicleId { get; set; }

        public int CurrencyId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }
        public decimal C3 { get; set; }
        public decimal C4 { get; set; }
        public decimal C5 { get; set; }
        public decimal C6 { get; set; }
        public decimal C7 { get; set; }
        public decimal C8 { get; set; }
        public decimal C9 { get; set; }

        public bool Privilege { get; set; }
        public string PrivilageSertificateName { get; set; }
        public string PrivilageSertificateSeries { get; set; }
        public string PrivilageSertificateNumber { get; set; }
        public DateTime PrivilageSertificateDate { get; set; }
        public string PrivilageSertificateIssuer { get; set; }

        // Rate calculator properties
        public int DriverExperienceId { get; set; }

        public int BonusMalusId { get; set; }

        public int DriversNumberId { get; set; }

        public int VehiclesNumberId { get; set; }

        public bool FraudAttemptId { get; set; }

        public int LocalityVehicleRegistrationId { get; set; }

        public int TerritoryRegistrationId { get; set; }

        public int AreasOfUseId { get; set; }

        public int ContractTermId { get; set; }

        public decimal Amount { get; set; }
        public decimal Premium { get; set; }

        public int BankAccountId { get; set; }

        public int DocumentCategoryId { get; set; }

        public int PreviousPolicyId { get; set; }

        public string Notes { get; set; }
    }
}
