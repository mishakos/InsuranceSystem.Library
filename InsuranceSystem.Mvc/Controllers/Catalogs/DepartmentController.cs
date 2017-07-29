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
    public class DepartmentController : Controller
    {
        private IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        // GET: Department
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<DepartmentDTO>, List<DepartmentModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: Department/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<DepartmentDTO, DepartmentModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            var model = new DepartmentModel();
            return View(model);
        }

        // POST: Department/Create
        [HttpPost]
        public async Task<ActionResult> Create(DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var departmentDto = Mapper.Map<DepartmentModel, DepartmentDTO>(model);
                    await _service.InsertAsync(departmentDto);
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

        // GET: Department/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<DepartmentDTO, DepartmentModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var departmentDto = Mapper.Map<DepartmentModel, DepartmentDTO>(model);
                    departmentDto.Id = id;
                    await _service.UpdateAsync(departmentDto);
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

        // GET: Department/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<DepartmentDTO, DepartmentModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Department/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DepartmentModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.DeleteAsync(id);
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

        private new void  Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
