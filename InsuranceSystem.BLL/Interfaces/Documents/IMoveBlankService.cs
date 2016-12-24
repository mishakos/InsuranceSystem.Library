namespace InsuranceSystem.BLL.Interfaces.Documents
{
    using DTO.Documents;
    using System.Collections.Generic;

    public interface IMoveBlankService
    {
        void MakeMoveBlank(MoveBlankDTO moveBlankDTO);
        MoveBlankDTO GetMoveBlank(int? id);
        IEnumerable<MoveBlankDTO> GetMoveBlanks();
        void UpdateMoveBlank(MoveBlankDTO moveBlankDTO);
        void HoldMoveBlank(int? id);
        void UnHoldMoveBlank(int? id);
        void DeleteMoveBlank(int? id);
        void Dispose();
    }
}
