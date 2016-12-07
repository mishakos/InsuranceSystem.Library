namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBlankService : IService<BlankDTO>
    {
        Task<List<BlankDTO>> GetByBlankTypeId(int? id);
    }
}
