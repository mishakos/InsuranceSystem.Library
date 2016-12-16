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
    public class BrandController : Controller
    {
        IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }


        // GET: Brand
#pragma warning disable IDE1006 // Naming Styles
        public async Task<ActionResult> Index()
#pragma warning restore IDE1006 // Naming Styles
        {
            var brands = Mapper.Map<List<BrandDTO>, List<BrandModel>>(await _service.GetAllAsync());
            return View(brands);
        }

        // GET: Brand/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<BrandDTO, BrandModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            var model = new BrandModel();
            return View(model);
        }

        // POST: Brand/Create
        [HttpPost]
        public async Task<ActionResult> Create(BrandModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var modelDto = Mapper.Map<BrandModel, BrandDTO>(model);
                    await _service.InsertAsync(modelDto);
                    return RedirectToAction("Index");
                }
                else
                    return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"{ex.Message}: {ex.InnerException?.Message} {ex.InnerException?.InnerException?.Message} ");
                return View(model);
            }
        }

        // GET: Brand/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<BrandDTO, BrandModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Brand/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BrandModel model)
        {
            try
            {
                var brandDto = await _service.GetByIdAsync(id);
                brandDto.IsDelete = model.IsDelete;
                brandDto.IsGroup = model.IsGroup;
                brandDto.Name = model.Name;
                brandDto.ParentId = model.ParentId;
                
                await _service.UpdateAsync(brandDto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Brand/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<BrandDTO, BrandModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Brand/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BrandModel model)
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

        public new void Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
