using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.BLL.Services.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class BlankTypeController : Controller
    {
        private IBlankTypeService _service;
        public BlankTypeController()
        {
            _service = new BlankTypeService();
        }

        // GET: BlancType
        public async Task<ActionResult> Index()
        {
            var blankTypes = Mapper.Map<List<BlankTypeModel>>( await _service.GetAllAsync());
            return View(blankTypes);
        }

        // GET: BlancType/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var blankType = Mapper.Map<BlankTypeModel>(await _service.GetByIdAsync(id));
            return View(blankType);
        }

        // GET: BlancType/Create
        public ActionResult Create()
        {
            var model = new BlankTypeModel();
            return View(model);
        }

        // POST: BlancType/Create
        [HttpPost]
        public ActionResult Create(BlankTypeModel blankTypeModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = Mapper.Map<BlankTypeModel, BlankTypeDTO>(blankTypeModel);
                    _service.InsertAsync(item);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(blankTypeModel);
            }
        }

        // GET: BlancType/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<BlankTypeModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BlancType/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BlankTypeModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var blankTypeDTO = Mapper.Map<BlankTypeDTO>(model);
                    await _service.UpdateAsync(blankTypeDTO);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
                
            }
            catch
            {
                return View(model);
            }
        }

        // GET: BlancType/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<BlankTypeModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BlancType/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BlankTypeModel model)
        {
            try
            {
                await _service.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
