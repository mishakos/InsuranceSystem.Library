namespace InsuranceSystem.MVC.Models.Catalogs
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BlankModel : CatalogModel
    {
        [Display(Name = "Тип бланку")]
        public int? BlankTypeId { get; set; }
        [Display(Name = "Тип бланку")]
        public string BlankTypeName { get; set; }

        public virtual List<BlankTypeModel> BlankTypes { get; set; } = new List<BlankTypeModel>();
    }
}
