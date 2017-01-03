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
    public class DriversNumberController : Controller
    {
        private IDriversNumberService _service;
        public DriversNumberController(IDriversNumberService service)
        {
            _service = service;
        }

        // GET: DriversNumber
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<DriversNumberDTO>, List<DriversNumberModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: DriversNumber/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<DriversNumberDTO, DriversNumberModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: DriversNumber/Create
        public ActionResult Create()
        {
            var model = new DriversNumberModel();
            return View(model);
        }

        // POST: DriversNumber/Create
        [HttpPost]
        public async Task<ActionResult> Create(DriversNumberModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var driversNumberDto = Mapper.Map<DriversNumberModel, DriversNumberDTO>(model);
                    await _service.InsertAsync(driversNumberDto);
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

        // GET: DriversNumber/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<DriversNumberDTO, DriversNumberModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DriversNumber/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DriversNumberModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var driversNumber = Mapper.Map<DriversNumberModel, DriversNumberDTO>(model);
                    driversNumber.Id = id;
                    await _service.UpdateAsync(driversNumber);
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

        // GET: DriversNumber/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<DriversNumberDTO, DriversNumberModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DriversNumber/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DriversNumberModel model)
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
