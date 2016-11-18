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

    public class MoveBlankService : IMoveBlankService, IService<MoveBlankDTO>
    {
        readonly IUnitOfWork<MoveBlank> moveBlankUnit;

        public MoveBlankService()
        {
            moveBlankUnit = new MoveBlankUnit();
        }

        public int Delete(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void DeleteMoveBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public Task<MoveBlankDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MoveBlankDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public MoveBlankDTO GetMoveBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MoveBlankDTO> GetMoveBlanks()
        {
            throw new NotImplementedException();
        }

        public void HoldMoveBlank(int? id)
        {
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

        public void MakeMoveBlank(MoveBlankDTO moveBlankDTO)
        {
            throw new NotImplementedException();
        }

        public void UnHoldMoveBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public int Update(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MoveBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateMoveBlank(MoveBlankDTO moveBlankDTO)
        {
            throw new NotImplementedException();
        }
    }
}
