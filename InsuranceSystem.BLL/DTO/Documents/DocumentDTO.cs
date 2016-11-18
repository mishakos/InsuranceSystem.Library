using System;

namespace InsuranceSystem.BLL.DTO.Documents
{
    public abstract class DocumentDTO
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
