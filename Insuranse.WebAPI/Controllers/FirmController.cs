using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.BLL.Services.Catalogs;
using Insuranse.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Insuranse.WebAPI.Controllers
{
    public class FirmController : ApiController
    {
        private IFirmService _service = new FirmService();

        // GET: api/Firm
        public async Task<List<FirmModel>> Get()
        {
            var firms = Mapper.Map<IEnumerable<FirmDTO>, List<FirmModel>>(await _service.GetAllAsync());
            return firms;
        }

        // GET: api/Firm/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Firm
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Firm/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Firm/5
        public void Delete(int id)
        {
        }
    }
}
