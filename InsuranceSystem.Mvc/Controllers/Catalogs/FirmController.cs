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
    public class FirmController : Controller
    {
        private IFirmService _service;
        public FirmController(IFirmService service)
        {
            _service = service;
        }

        // GET: Firm
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<IEnumerable<FirmDTO>, List<FirmModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: Firm/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<FirmDTO, FirmModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: Firm/Create
        public ActionResult Create()
        {
            var model = new FirmModel();
            return View(model);
        }

        // POST: Firm/Create
        [HttpPost]
        public async Task<ActionResult> Create(FirmModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var firmDto = Mapper.Map<FirmModel, FirmDTO>(model);
                    await _service.InsertAsync(firmDto);

                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
                return View(model);
            }
        }

        // GET: Firm/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<FirmDTO, FirmModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Firm/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FirmModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var firmDto = Mapper.Map<FirmModel, FirmDTO>(model);
                    firmDto.Id = id;
                    await _service.InsertAsync(firmDto);
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

        // GET: Firm/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<FirmDTO, FirmModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Firm/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FirmModel model)
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
