namespace InsuranceSystem.BLL.Interfaces.Documents
{
    using DTO.Documents;
    using System.Collections.Generic;

    public interface IPostBlankService
    {
        void MakePostBlank(PostBlankDTO postBlankDTO);
        PostBlankDTO GetPostBlank(int? id);
        IEnumerable<PostBlankDTO> GetPostBlanks();
        void UpdatePostBlank(PostBlankDTO postBlankDTO);
        void HoldPostBlank(int? id);
        void UnHoldPostBlank(int? id);
        void SetDeletePostBlank(int? id);
        void Dispose();
    }
}
