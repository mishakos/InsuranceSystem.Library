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
    public class BankAccountController : Controller
    {
        private IBankAccountService _service;

        public BankAccountController(IBankAccountService service)
        {
            _service = service;
        }

        // GET: BankAccount
        public async Task<ActionResult> Index()
        {
            var model = Mapper.Map<List<BankAccountDTO>, List<BankAccountModel>>(await _service.GetAllAsync());
            return View(model);
        }

        // GET: BankAccount/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<BankAccountDTO, BankAccountModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            var model = new BankAccountModel();
            return View(model);
        }

        // POST: BankAccount/Create
        [HttpPost]
        public async Task<ActionResult> Create(BankAccountModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bankAccountDto = Mapper.Map<BankAccountModel, BankAccountDTO>(model);
                    await _service.InsertAsync(bankAccountDto);
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

        // GET: BankAccount/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<BankAccountDTO, BankAccountModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, BankAccountModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var bankAccountDto = Mapper.Map<BankAccountModel, BankAccountDTO>(model);
                    bankAccountDto.Id = id;
                    await _service.UpdateAsync(bankAccountDto);
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

        // GET: BankAccount/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<BankAccountDTO, BankAccountModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, BankAccountModel model)
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
        private new void Dispose()
        {
            _service.Dispose();
            base.Dispose();
        }
    }
}
