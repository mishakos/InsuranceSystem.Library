
namespace InsuranceSystem.MVC.Models.Documents
{
    using System.Collections.Generic;

    public class MoveBlankModel : DocumentModel
    {
        public int FromPersonId { get; set; }
        public int ToPersonId { get; set; }
        public virtual List<MoveBlankItemModel> MoveBlankItems { get; set; }


    }
}
