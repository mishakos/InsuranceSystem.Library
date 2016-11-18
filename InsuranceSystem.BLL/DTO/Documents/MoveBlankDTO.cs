
namespace InsuranceSystem.BLL.DTO.Documents
{
    using System.Collections.Generic;

    public class MoveBlankDTO : DocumentDTO
    {
        public int FromPersonId { get; set; }
        public int ToPersonId { get; set; }
        public virtual List<MoveBlankItemDTO> MoveBlankItems { get; set; }


    }
}
