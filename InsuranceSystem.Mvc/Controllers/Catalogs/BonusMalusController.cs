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
    public class BonusMalusController : Controller
    {
        private IBonusMalusService _service;
        public BonusMalusController(IBonusMalusService service)
        {
            _service = service;
        }
        // GET: BonusMalus
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<BonusMalusDTO>, List<BonusMalusModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: BonusMalus/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<BonusMalusDTO, BonusMalusModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: BonusMalus/Create
        public ActionResult Create()
        {
            var model = new BonusMalusModel();
            return View(model);
        }

        // POST: BonusMalus/Create
        [HttpPost]
        public async Task<ActionResult> Create(BonusMalusModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bonusMalusDto = Mapper.Map<BonusMalusModel, BonusMalusDTO>(model);
                    await _service.InsertAsync(bonusMalusDto);
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

        // GET: BonusMalus/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<BonusMalusDTO, BonusMalusModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BonusMalus/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BonusMalusModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var bonusMalusDto = Mapper.Map<BonusMalusModel, BonusMalusDTO>(model);
                    bonusMalusDto.Id = id;
                    await _service.UpdateAsync(bonusMalusDto);
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

        // GET: BonusMalus/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<BonusMalusDTO, BonusMalusModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BonusMalus/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BonusMalusModel model)
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
    }
}
