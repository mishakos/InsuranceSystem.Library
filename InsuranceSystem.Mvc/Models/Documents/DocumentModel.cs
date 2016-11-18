using System;

namespace InsuranceSystem.MVC.Models.Documents
{
    public abstract class DocumentModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public bool IsHold { get; set; }
        public bool IsDelete { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int AuthorId { get; set; }

    }
}
