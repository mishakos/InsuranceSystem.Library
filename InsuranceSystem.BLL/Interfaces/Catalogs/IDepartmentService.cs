﻿namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IDepartmentService : IService<DepartmentDTO>
    {
        Task<List<DepartmentDTO>> GetByFirmIdAsync(int? id);
    }
}
