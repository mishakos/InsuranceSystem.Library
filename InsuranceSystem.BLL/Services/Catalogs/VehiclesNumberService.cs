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
    using static Validation.CheckValues;
    using Interfaces;
    using UnitOfWork;
    using System.Threading.Tasks;

    public class VehiclesNumberService : IVehiclesNumberService
    {
        readonly IUnitOfWork<VehiclesNumber> vnUnit;
        readonly AutoMapperConfig autoMapperConfig;

        public VehiclesNumberService()
        {
            autoMapperConfig = AutoMapperConfig.Instance;
            vnUnit = new VehiclesNumberUnit();
        }

        public int Delete(VehiclesNumberDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            vnUnit.Repository.Delete(entity.Id);
            return vnUnit.Commit();
        }

        public int Delete(int? id)
        {
            CheckForNull(id);
            vnUnit.Repository.Delete((int)id);
            return vnUnit.Commit();
        }

        public async Task<int> DeleteAsync(VehiclesNumberDTO entity)
        {
            CheckForNull(entity);
            CheckForNull(entity.Id);
            vnUnit.Repository.Delete(entity.Id);
            return await vnUnit.CommitAsync();
        }

        public async Task<int> DeleteAsync(int? id)
        {
            CheckForNull(id);
            vnUnit.Repository.Delete((int)id);
            return await vnUnit.CommitAsync();
        }

        public void Dispose()
        {
            vnUnit.Dispose();
        }

        public IEnumerable<VehiclesNumberDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<VehiclesNumber>, List<VehiclesNumberDTO>>(vnUnit.Repository.GetAll());
        }

        public async Task<List<VehiclesNumberDTO>> GetAllAsync()
        {
            return Mapper.Map<List<VehiclesNumber>, List<VehiclesNumberDTO>>(await vnUnit.Repository.GetAllAsync());
        }

        public VehiclesNumberDTO GetById(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<VehiclesNumber, VehiclesNumberDTO>(vnUnit.Repository.GetById((int)id));
        }

        public async Task<VehiclesNumberDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            return Mapper.Map<VehiclesNumber, VehiclesNumberDTO>(await vnUnit.Repository.GetAsync(p => p.Id == id));
        }

        public async Task<List<VehiclesNumberDTO>> GetByNameAsync(string name)
        {
            return Mapper.Map<List<VehiclesNumber>, List<VehiclesNumberDTO>>(await vnUnit.Repository.GetManyAsync(p => p.Name.ToUpper().Contains(name.ToUpper())));
        }

        public int Insert(VehiclesNumberDTO entity)
        {
            var model = Mapper.Map<VehiclesNumberDTO, VehiclesNumber>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            vnUnit.Repository.Insert(model);
            return vnUnit.Commit();
        }

        public async Task<int> InsertAsync(VehiclesNumberDTO entity)
        {
            var model = Mapper.Map<VehiclesNumberDTO, VehiclesNumber>(entity);
            model.DateCreate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            vnUnit.Repository.Insert(model);
            return await  vnUnit.CommitAsync();
        }

        public int Update(VehiclesNumberDTO entity)
        {
            var model = vnUnit.Repository.GetById(entity.Id);
            MapModel(entity, model);
            vnUnit.Repository.Update(model);
            return vnUnit.Commit();
        }

        private static void MapModel(VehiclesNumberDTO entity, VehiclesNumber model)
        {
            model.IsDelete = entity.IsDelete;
            model.IsGroup = entity.IsGroup;
            model.ModifiedDate = DateTime.Now;
            model.Name = entity.Name;
            model.ParentId = entity.ParentId;
        }

        public async Task<int> UpdateAsync(VehiclesNumberDTO entity)
        {
            var model = await  vnUnit.Repository.GetAsync(p => p.Id == entity.Id);
            MapModel(entity, model);
            vnUnit.Repository.Update(model);
            return await  vnUnit.CommitAsync();
        }
    }
}
