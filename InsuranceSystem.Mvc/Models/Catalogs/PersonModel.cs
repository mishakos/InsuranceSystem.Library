using System;

namespace InsuranceSystem.MVC.Models.Catalogs
{
    public class PersonModel : CatalogModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentSeries { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime DocumentDate { get; set; }
        public string DocumentWhoGive { get; set; }
        public DateTime BirthDate { get; set; }
        public string CodeDRFO { get; set; }
        public string EMail { get; set; }
        public int AdressId { get; set; }

    }
}
