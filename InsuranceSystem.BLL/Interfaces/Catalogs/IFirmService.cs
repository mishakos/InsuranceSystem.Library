namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IFirmService : IService<FirmDTO>
    {
        Task<List<FirmDTO>> GetByEDRPOUAsync(string edrpou);
    }
}
