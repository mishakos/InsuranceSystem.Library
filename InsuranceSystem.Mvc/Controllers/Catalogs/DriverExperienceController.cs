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
    public class DriverExperienceController : Controller
    {
        private IDriverExperienceService _service;

        public DriverExperienceController(IDriverExperienceService service)
        {
            _service = service;
        }
        // GET: DriverExperience
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<DriverExperienceDTO>, List<DriverExperienceModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: DriverExperience/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<DriverExperienceDTO, DriverExperienceModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: DriverExperience/Create
        public ActionResult Create()
        {
            var model = new DriverExperienceModel();
            return View(model);
        }

        // POST: DriverExperience/Create
        [HttpPost]
        public async Task<ActionResult> Create(DriverExperienceModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var driverExp = Mapper.Map<DriverExperienceModel, DriverExperienceDTO>(model);
                    await _service.InsertAsync(driverExp);
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

        // GET: DriverExperience/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<DriverExperienceDTO, DriverExperienceModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DriverExperience/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DriverExperienceModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var driverExp = Mapper.Map<DriverExperienceModel, DriverExperienceDTO>(model);
                    driverExp.Id = id;
                    await _service.UpdateAsync(driverExp);
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

        // GET: DriverExperience/Delete/5
        public async  Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<DriverExperienceDTO, DriverExperienceModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DriverExperience/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DriverExperienceModel model)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
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
