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
    public class DocumentCategoryController : Controller
    {
        private IDocumentCategoryService _service;
        public DocumentCategoryController(IDocumentCategoryService service)
        {
            _service = service;
        }
        // GET: DocumentCategory
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<IEnumerable<DocumentCategoryDTO>, IEnumerable<DocumentCategoryModel>>(await _service.GetAllAsync()); 
            return View(model);
        }

        // GET: DocumentCategory/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<DocumentCategoryDTO, DocumentCategoryModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: DocumentCategory/Create
        public ActionResult Create()
        {
            var model = new DocumentCategoryModel();
            return View(model);
        }

        // POST: DocumentCategory/Create
        [HttpPost]
        public async Task<ActionResult> Create(DocumentCategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var documentDto = Mapper.Map<DocumentCategoryModel, DocumentCategoryDTO>(model);
                    await _service.InsertAsync(documentDto);
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

        // GET: DocumentCategory/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<DocumentCategoryDTO, DocumentCategoryModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DocumentCategory/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, DocumentCategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var documentDto = Mapper.Map<DocumentCategoryModel, DocumentCategoryDTO>(model);
                    documentDto.Id = id;
                    await _service.UpdateAsync(documentDto);
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

        // GET: DocumentCategory/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<DocumentCategoryDTO, DocumentCategoryModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: DocumentCategory/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, DocumentCategoryModel model)
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

        private new void  Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
