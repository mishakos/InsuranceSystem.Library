namespace InsuranceSystem.BLL.Services.Documents
{
    using AutoMapper;
    using DTO.Catalogs;
    using Infrastructure;
    using Interfaces.Documents;
    using Library.Models.Documents;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.Documents;
    using DTO.Documents;
    using static Validation.CheckValues;
    using Interfaces;
    using System.Threading.Tasks;
    using UnitOfWork;

    public class MoveBlankService : IMoveBlankService
    {
        readonly IUnitOfWork<MoveBlank> moveBlankUnit;

        public MoveBlankService()
        {
            moveBlankUnit = new MoveBlankUnit();
        }

        public async Task DeleteMoveBlankAsync(int? id)
        {
            CheckForNull(id);
            moveBlankUnit.Repository.Delete((int)id);
            await moveBlankUnit.CommitAsync();
        }

        public void Dispose()
        {
            moveBlankUnit.Dispose();
        }

        public IEnumerable<MoveBlankDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<MoveBlankDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public MoveBlankDTO GetById(int? id)
        {
            CheckForNull(id);
            var item = moveBlankUnit.Repository.GetById((int)id);
            CheckForNull(item);
            return Mapper.Map<MoveBlank, MoveBlankDTO>(item);
        }

        public async Task<MoveBlankDTO> GetByIdAsync(int? id)
        {
            CheckForNull(id);
            var item = await moveBlankUnit.Repository.GetAsync(p => p.Id == id);
            return Mapper.Map<MoveBlank, MoveBlankDTO>(item);
        }

        public async Task<List<MoveBlankDTO>> GetByNumberAsync(string name)
        {
            return Mapper.Map<List<MoveBlank>, List<MoveBlankDTO>>(await moveBlankUnit
                .Repository.GetManyAsync(p => p.Number.ToLower().Contains(name.ToLower())));
        }

        public async Task<IEnumerable<MoveBlankDTO>> GetMoveBlanksAsync()
        {
            return Mapper.Map<IEnumerable<MoveBlank>, List<MoveBlankDTO>>(await moveBlankUnit
                .Repository.GetAllAsync());
        }

        public async Task HoldMoveBlankAsync(int? id)
        {
            CheckForNull(id);
            throw new NotImplementedException();
        }

        public int Insert(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task MakeMoveBlankAsync(MoveBlankDTO moveBlankDTO)
        {
            throw new NotImplementedException();
        }

        public Task UnHoldMoveBlankAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public int Update(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMoveBlankAsync(MoveBlankDTO moveBlankDTO)
        {
            throw new NotImplementedException();
        }
    }
}
