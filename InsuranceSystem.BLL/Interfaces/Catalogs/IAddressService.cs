using InsuranceSystem.BLL.DTO.Catalogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    public interface IAddressService : IService<AddressDTO>
    {
        Task<List<AddressDTO>> GetByFirstLineAsync(string firstLine);
        Task<List<AddressDTO>> GetBySecondLineAsync(string secondAddress);
        Task<List<AddressDTO>> GetByCountyAsync(string county);
        Task<List<AddressDTO>> GetByCityAsync(string city);
        Task<List<AddressDTO>> GetByStateAsync(string state);
        Task<List<AddressDTO>> GetByZipAsync(string zip);
        Task<List<AddressDTO>> GetByCountryAsync(string country);
    }
}
