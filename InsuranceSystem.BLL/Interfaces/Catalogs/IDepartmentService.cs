namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    interface IDepartmentService
    {
        Task<List<DepartmentDTO>> GetByFirmIdAsync(int? id);
    }
}
