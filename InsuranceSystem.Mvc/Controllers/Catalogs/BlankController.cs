using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.BLL.Services.Catalogs;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class BlankController : Controller
    {
        private IBlankService blankService;

        public BlankController()
        {
            blankService = new BlankService();
        }
        // GET: Blank
        public ActionResult Index()
        {

            return View();
        }

        // GET: Blank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Blank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blank/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Blank/Edit/5
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

        // GET: Blank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Blank/Delete/5
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
