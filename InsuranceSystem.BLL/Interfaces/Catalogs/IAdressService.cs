namespace InsuranceSystem.BLL.Interfaces.Catalogs
{
    using DTO.Catalogs;
    using System.Collections.Generic;

    interface IAdressService
    {
        void MakeAdress(AdressDTO adressDTO);
        AdressDTO GetAdress(int? id);
        IEnumerable<AdressDTO> GetAdresses();
        void UpdateAdress(AdressDTO adressDTO);
        void SetDeleteAdress(int? id);
        void Dispose();
    }
}
