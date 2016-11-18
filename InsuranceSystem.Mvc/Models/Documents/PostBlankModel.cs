using System.Collections.Generic;

namespace InsuranceSystem.MVC.Models.Documents
{
    public class PostBlankModel : DocumentModel
    {
        public int MRPersonId { get; set; }
        public List<PostBlankItemModel> BlankItems { get; set; }

    }
}
