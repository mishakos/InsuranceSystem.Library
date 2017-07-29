using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.Mvc.App_Start;
using InsuranceSystem.MVC.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class AreaOfUseController : Controller
    {
        private IAreaOfUseService _service;

        public AreaOfUseController(IAreaOfUseService service)
        {
            _service = service;
        }

        // GET: AreaOfUse
        public async Task<ActionResult> Index()
        {
            AutoMapperConfig.CreateMap<AreaOfUseDTO, AreaOfUseModel>();
            var model = Mapper.Map<List<AreaOfUseDTO>, List<AreaOfUseModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: AreaOfUse/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<AreaOfUseDTO, AreaOfUseModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: AreaOfUse/Create
        public ActionResult Create()
        {
            var model = new AreaOfUseModel();
            return View(model);
        }

        // POST: AreaOfUse/Create
        [HttpPost]
        public async Task<ActionResult> Create(AreaOfUseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var areaOfUseDto = Mapper.Map<AreaOfUseModel, AreaOfUseDTO>(model);
                    await _service.InsertAsync(areaOfUseDto);
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

        // GET: AreaOfUse/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<AreaOfUseDTO, AreaOfUseModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: AreaOfUse/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, AreaOfUseModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var areaOfUseDto = Mapper.Map<AreaOfUseModel, AreaOfUseDTO>(model);
                    areaOfUseDto.Id = id;
                    await _service.UpdateAsync(areaOfUseDto);
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

        // GET: AreaOfUse/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<AreaOfUseDTO, AreaOfUseModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: AreaOfUse/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, AreaOfUseModel model)
        {
            try
            {
                await _service.DeleteAsync(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
        private new void Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
