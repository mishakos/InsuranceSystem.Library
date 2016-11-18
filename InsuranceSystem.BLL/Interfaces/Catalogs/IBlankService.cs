namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBlankService
    {
        Task<List<BlankDTO>> GetByBlankTypeId(int? id);
    }
}
