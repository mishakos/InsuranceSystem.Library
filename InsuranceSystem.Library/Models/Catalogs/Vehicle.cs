﻿namespace InsuranceSystem.Library.Models.Catalogs
{
    using Documents;
    using System;
    using System.Collections.Generic;

    public class Vehicle : Catalog
    {
        public int ModelId { get; set; }
        public virtual Model Model { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public string Vin { get; set; }
        public string RegNumber { get; set; }
        public string Comments { get; set; }
        public int EngineCapacity { get; set; }
        public DateTime OperationFrom { get; set; }
        public decimal Load { get; set; }
        public string PlaceOfRegistration { get; set; }
        public DateTime SertificateDate { get; set; }
        public string SertificateSeries { get; set; }
        public string SertificateNumber { get; set; }
        public string SertificateIssuer { get; set; }

        public virtual List<MTPLPolicy> MTPLPolicies { get; set; }

    }
}
