namespace InsuranceSystem.BLL.Interfaces.Documents
{
    using DTO.Documents;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMoveBlankService
    {
        Task MakeMoveBlankAsync(MoveBlankDTO moveBlankDTO);
        MoveBlankDTO GetById(int? id);
        Task<MoveBlankDTO> GetByIdAsync(int? id);
        Task<IEnumerable<MoveBlankDTO>> GetMoveBlanksAsync();
        Task UpdateMoveBlankAsync(MoveBlankDTO moveBlankDTO);
        Task HoldMoveBlankAsync(int? id);
        Task UnHoldMoveBlankAsync(int? id);
        Task DeleteMoveBlankAsync(int? id);
        void Dispose();
    }
}