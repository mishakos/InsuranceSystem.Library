
namespace InsuranceSystem.Library.Models.Documents
{
    using Catalogs;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class MTPLPolicy : Document
    {
        [Required]
        public int PolicyId { get; set; }
        public virtual Blank Policy { get; set; }

        public int StickerId { get; set; }
        public virtual Blank Sticker { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int BeneficiaryClientId { get; set; }
        public virtual Client BeneficiaryClient { get; set; }

        public int BeneficiaryBankId { get; set; }
        public virtual Bank BeneficiaryBank { get; set; }

        public int FirmId { get; set; }
        public virtual Firm Firm { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public int SalesOfficeId { get; set; }
        public virtual SalesOffice SalesOffice { get; set; }

        public int InsuranceProductId { get; set; }
        public virtual InsuranceProduct InsuranceProduct { get; set; }
        
        public int InsuranceTypeId { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }
        
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicles { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

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
        public virtual DriverExperience DriverExperience { get; set; }

        public int BonusMalusId { get; set; }
        public virtual BonusMalus BonusMalus { get; set; }

        public int DriversNumberId { get; set; }
        public virtual DriversNumber DriversNumber { get; set; }

        public int VehiclesNumberId { get; set; }
        public virtual VehiclesNumber VehiclesNumber { get; set; }

        public bool FraudAttemptId { get; set; }
        public virtual FraudAttempt FraudAttempt { get; set; }

        public int LocalityVehicleRegistrationId { get; set; }
        public virtual LocalityVehicleRegistration LocalityVehicleRegistration { get; set; }

        public int TerritoryRegistrationId { get; set; }
        public virtual TerritoryRegistration TerritoryRegistration { get; set; }

        public int AreasOfUseId { get; set; }
        public virtual AreaOfUse AreasOfUse { get; set; }

        public int ContractTermId { get; set; }
        public virtual ContractTerm ContractTerm { get; set; }

        public decimal Amount { get; set; }
        public decimal Premium { get; set; }

        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public int DocumentCategoryId { get; set; }
        public virtual DocumentCategory DocumentCategory { get; set; }

        public int PreviousPolicyId { get; set; }
        public virtual MTPLPolicy PreviousPolicy { get; set; }

        public string Notes { get; set; }
    }
}
