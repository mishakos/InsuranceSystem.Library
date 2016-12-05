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
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlancType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlancType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlancType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
