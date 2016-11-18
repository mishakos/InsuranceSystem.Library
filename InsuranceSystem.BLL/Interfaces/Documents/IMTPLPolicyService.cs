namespace InsuranceSystem.BLL.Interfaces.Documents
{
    using DTO.Documents;
    using System.Collections.Generic;

    interface IMTPLPolicyService
    {
        void MakeMTPLPolicy(MTPLPolicyDTO mtplPolicyDTO);
        MTPLPolicyDTO GetMTPLPolicy(int? id);
        IEnumerable<MTPLPolicyDTO> GetMTPLPolicies();
        void UpdateMTPLPolicy(MTPLPolicyDTO mtplPolicyDTO);
        void HoldMTPLPolicy(int? id);
        void UnHoldMTPLPolicyDTO(int? id);
        void SetDeleteMTPLPolicyDTO(int? id);
        void Dispose();
    }
}
