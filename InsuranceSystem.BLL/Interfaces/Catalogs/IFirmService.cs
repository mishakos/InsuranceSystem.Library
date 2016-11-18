namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    interface IFirmService
    {
        Task<List<FirmDTO>> GetByEDRPOUAsync(string edrpou);
    }
}
