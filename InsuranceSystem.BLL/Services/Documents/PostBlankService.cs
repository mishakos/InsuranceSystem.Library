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
    using UnitOfWork;
    using System.Threading.Tasks;

    public class PostBlankService : IPostBlankService, IService<PostBlankDTO>
    {
        readonly IUnitOfWork<PostBlank> postBlankUnit;

        public PostBlankService()
        {
            postBlankUnit = new PostBlankUnit();
        }

        public int Delete(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            postBlankUnit.Dispose();
        }

        public IEnumerable<PostBlankDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<PostBlankDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public PostBlankDTO GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PostBlankDTO> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PostBlankDTO>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public PostBlankDTO GetPostBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostBlankDTO> GetPostBlanks()
        {
            throw new NotImplementedException();
        }

        public void HoldPostBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public int Insert(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public void MakePostBlank(PostBlankDTO postBlankDTO)
        {
            throw new NotImplementedException();
        }

        public void SetDeletePostBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public void UnHoldPostBlank(int? id)
        {
            throw new NotImplementedException();
        }

        public int Update(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(PostBlankDTO entity)
        {
            throw new NotImplementedException();
        }

        public void UpdatePostBlank(PostBlankDTO postBlankDTO)
        {
            throw new NotImplementedException();
        }
    }
}
