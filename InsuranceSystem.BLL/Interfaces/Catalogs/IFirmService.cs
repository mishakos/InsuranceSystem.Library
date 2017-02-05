namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IFirmService //: IService<FirmDTO>
    {
        Task<IEnumerable<FirmDTO>> GetByEDRPOUAsync(string edrpou);
        FirmDTO GetById(int? id);

        Task<IEnumerable<FirmDTO>> GetAllAsync();
        Task<FirmDTO> GetByIdAsync(int? id);
        Task<IEnumerable<FirmDTO>> GetByNameAsync(string name);
        Task<int> InsertAsync(FirmDTO entity);
        Task<int> UpdateAsync(FirmDTO entity);
        Task<int> DeleteAsync(int? id);
        Task<int> DeleteAsync(FirmDTO entity);
        void Dispose();

    }
}
