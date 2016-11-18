namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IAreaOfUseService
    {
        Task<List<AreaOfUseDTO>> GetByParentAsync(int? id);
    }
}
