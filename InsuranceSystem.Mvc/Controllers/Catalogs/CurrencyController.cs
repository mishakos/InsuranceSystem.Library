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
    public class CurrencyController : Controller
    {
        private ICurrencyService _service;

        public CurrencyController(ICurrencyService service)
        {
            _service = service;
        }

        // GET: Currency
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<CurrencyDTO>, List<CurrencyModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: Currency/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<CurrencyDTO, CurrencyModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            var model = new CurrencyModel();
            return View(model);
        }

        // POST: Currency/Create
        [HttpPost]
        public async Task<ActionResult> Create(CurrencyModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currencyDto = Mapper.Map<CurrencyModel, CurrencyDTO>(model);
                    await _service.InsertAsync(currencyDto);
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

        // GET: Currency/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<CurrencyDTO, CurrencyDTO>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Currency/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CurrencyModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var currencyDto = Mapper.Map<CurrencyModel, CurrencyDTO>(model);
                    currencyDto.Id = id;
                    await _service.UpdateAsync(currencyDto);
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

        // GET: Currency/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<CurrencyDTO, CurrencyModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Currency/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CurrencyModel model)
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
