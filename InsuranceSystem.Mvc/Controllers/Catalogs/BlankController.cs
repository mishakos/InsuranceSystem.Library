using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces;
using InsuranceSystem.BLL.Services.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class BlankController : Controller
    {
        private IService<BlankDTO> blankService;

        public BlankController()
        {
            blankService = new BlankService();
        }
        // GET: Blank
        public async Task<ActionResult> Index()
        {
            var items = await blankService.GetAllAsync();
            return View(Mapper.Map<IEnumerable<BlankDTO>, List<BlankModel>>(items));
        }

        // GET: Blank/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var blankDto = await blankService.GetByIdAsync(id);
            var model = Mapper.Map<BlankDTO, BlankModel>(blankDto);
            return View(model);
        }

        // GET: Blank/Create
        public ActionResult Create()
        {
            var model = new BlankModel();
            return View(model);
        }

        // POST: Blank/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Exclude = "Id, DateCreate, ModifiedDate")]BlankModel model)
        {
            try
            {
                var blank = Mapper.Map<BlankModel, BlankDTO>(model);
                await blankService.InsertAsync(blank);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Blank/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<BlankModel>(await blankService.GetByIdAsync(id));
            return View(model);
        }

        // POST: Blank/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BlankModel model)
        {
            try
            {
                var blankDto = Mapper.Map<BlankDTO>(model);
                await blankService.UpdateAsync(blankDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Blank/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<BlankModel>(await blankService.GetByIdAsync(id));
            return View(model);
        }

        // POST: Blank/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BlankModel model)
        {
            try
            {
                await blankService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
