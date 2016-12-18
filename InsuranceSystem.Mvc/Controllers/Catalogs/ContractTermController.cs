using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class ContractTermController : Controller
    {
        private IContractTermService _service;

        public ContractTermController(IContractTermService service)
        {
            _service = service;
        }

        // GET: ContractTerm
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<ContractTermDTO>, List<ContractTermModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: ContractTerm/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<ContractTermDTO, ContractTermModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: ContractTerm/Create
        public ActionResult Create()
        {
            var model = new ContractTermModel();
            return View(model);
        }

        // POST: ContractTerm/Create
        [HttpPost]
        public async Task<ActionResult> Create(ContractTermModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contractTermDto = Mapper.Map<ContractTermModel, ContractTermDTO>(model);
                    await _service.InsertAsync(contractTermDto);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: ContractTerm/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<ContractTermDTO, ContractTermModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: ContractTerm/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ContractTermModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contractTermDto = Mapper.Map<ContractTermModel, ContractTermDTO>(model);
                    contractTermDto.Id = id;
                    await _service.UpdateAsync(contractTermDto);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: ContractTerm/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<ContractTermDTO, ContractTermModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: ContractTerm/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ContractTermModel model)
        {
            try
            {
                await _service.DeleteAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
        private new void Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
