using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InsuranceSystem.BLL.Interfaces.Catalogs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InsuranceSystem.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class FirmController : Controller
    {
        private IFirmService _service;
        public FirmController(IFirmService service)
        {
            _service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var model =  _service.GetAll();
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
