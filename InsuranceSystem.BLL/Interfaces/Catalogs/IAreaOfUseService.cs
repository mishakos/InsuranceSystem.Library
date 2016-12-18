namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAreaOfUseService : IService<AreaOfUseDTO>
    {
        Task<List<AreaOfUseDTO>> GetByParentAsync(int? id);
    }
}
