namespace InsuranceSystem.MVC.Models.Catalogs
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class CatalogModel
    {
        [Display(Name = "Код")]
        public int Id { get; set; }
        [Display(Name ="Назва")]
        public string Name { get; set; }
        [Display(Name = "Помітка на вилучення")]
        public bool IsDelete { get; set; }
        [Display(Name = "Дата створення")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Дата останньої зміни")]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Це група")]
        public bool IsGroup { get; set; }
        [Display(Name = "Група")]
        public int? ParentId { get; set; }
        [Display(Name = "Група")]
        public string ParentName { get; set; }
    }
}
