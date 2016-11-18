namespace InsuranceSystem.MVC.Models.Catalogs
{
    using System;

    public abstract class CatalogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDelete { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsGroup { get; set; }
        public int ParentId { get; set; }
    }
}
