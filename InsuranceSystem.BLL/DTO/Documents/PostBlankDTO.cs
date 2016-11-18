using System.Collections.Generic;

namespace InsuranceSystem.BLL.DTO.Documents
{
    public class PostBlankDTO : DocumentDTO
    {
        public int MRPersonId { get; set; }
        public List<PostBlankItemDTO> BlankItems { get; set; }

    }
}
