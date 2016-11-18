namespace InsuranceSystem.BLL.Services.Catalogs
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Catalogs;
    using Library.Models.Catalogs;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Catalogs;

    public class AdressService : IAdressService
    {
        readonly AdressUnit adressUnit;
        public AdressService()
        {
            adressUnit = new AdressUnit();
        }

        public void SetDeleteAdress(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null", "");
            var item = adressUnit.AdressRepository.GetByID(id);
            item.IsDelete = !item.IsDelete;
            item.ModifiedDate = DateTime.Now;
            adressUnit.SaveChanges();
        }

        public void Dispose()
        {
            adressUnit.Dispose();
        }

        public AdressDTO GetAdress(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null", "");
            Mapper.CreateMap<Adress, AdressDTO>();
            return Mapper.Map<Adress, AdressDTO>(adressUnit.AdressRepository.GetByID(id));
        }

        public IEnumerable<AdressDTO> GetAdresses()
        {
            Mapper.CreateMap<Adress, AdressDTO>();
            return Mapper.Map<IEnumerable<Adress>, List<AdressDTO>>(adressUnit.AdressRepository.Get());
        }

        public void MakeAdress(AdressDTO adressDTO)
        {
            adressUnit.AdressRepository.Insert(new Adress
            {
                IsDelete = false,
                IsGroup = adressDTO.IsGroup,
                ParentId = adressDTO.ParentId,
                DateCreate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                City = adressDTO.City,
                Country = adressDTO.Country,
                County = adressDTO.County,
                FirstLineAdress = adressDTO.FirstLineAdress,
                Name = adressDTO.Name,
                SecondLineAdress = adressDTO.SecondLineAdress,
                State = adressDTO.State,
                Zip = adressDTO.Zip
            });
            adressUnit.SaveChanges();
        }

        public void UpdateAdress(AdressDTO adressDTO)
        {
            if (adressDTO == null)
                throw new ValidationException("adress is null", "");
            var item = adressUnit.AdressRepository.GetByID(adressDTO.Id);
            item.IsDelete = adressDTO.IsDelete;
            item.IsGroup = adressDTO.IsGroup;
            item.ParentId = adressDTO.ParentId;
            item.ModifiedDate = DateTime.Now;
            item.City = adressDTO.City;
            item.Country = adressDTO.Country;
            item.County = adressDTO.County;
            item.FirstLineAdress = adressDTO.FirstLineAdress;
            item.Name = adressDTO.Name;
            item.SecondLineAdress = adressDTO.SecondLineAdress;
            item.State = adressDTO.State;
            item.Zip = adressDTO.Zip;
            adressUnit.AdressRepository.Update(item);
            adressUnit.SaveChanges();
        }
    }
}
