using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.BLL.Services.Catalogs;
using InsuranceSystem.MVC.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceSystem.Mvc.Controllers.Catalogs
{
    public class BankController : Controller
    {
        BankService bankService;
        public BankController()
        {
            bankService = new BankService();
        }

        // GET: Bank
        public async System.Threading.Tasks.Task<ActionResult> Index(string sortOrder)
        {
            ViewBag.MFOSortParam = String.IsNullOrEmpty(sortOrder) ? "mfo_desc" : "";
            ViewBag.NameSortParam = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.RateSortParam = sortOrder == "Rate" ? "rate_desc" : "Rate";
            var list = new List<BankModel>();
            try
            {
                var collection = await bankService.GetAllAsync();
                list = Mapper.Map<List<BankDTO>, List<BankModel>>(collection);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to get list of banks. Detail info - {ex.Message}");
            }

            switch (sortOrder)
            {
                case "":
                    {
                        list = (List<BankModel>)list.OrderBy(p => p.MFO);
                        break;
                    }
                case "mfo_desc":
                    {
                        list = (List<BankModel>)list.OrderByDescending(p => p.MFO);
                        break;
                    }
                case "Name":
                    {
                        list = (List<BankModel>)list.OrderBy(p => p.Name);
                        break;
                    }
                case "name_desc":
                    {
                        list = (List<BankModel>)list.OrderByDescending(p => p.Name);
                        break;
                    }
                case "Rate":
                    {
                        list = (List<BankModel>)list.OrderBy(p => p.Rate);
                        break;
                    }
                case "rate_desc":
                    {
                        list = (List<BankModel>)list.OrderByDescending(p => p.Rate);
                        break;
                    }
            }

            return View(list);
        }

        // GET: Bank/Details/5
        public ActionResult Details(int id)
        {
            var model = new BankModel();
            try
            {
                var item = bankService.GetById(id);
                model = Mapper.Map<BankDTO, BankModel>(item);
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to show details. Details: {ex.Message}");
            }
            return RedirectToAction("Index");
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            var model = new BankModel();
            return View(model);
        }

        // POST: Bank/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id, DateCreate, ModifiedDate")] BankModel model)
        {
            try
            {                
                bankService.Insert(Mapper.Map<BankModel, BankDTO>(model));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to create item. Details: {ex.Message}");
                return View(model);
            }
        }

        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new BankModel();
            try
            {
                var item = bankService.GetById(id);
                model = Mapper.Map<BankDTO, BankModel>(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to get item to edit. Details: {ex.Message}");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Bank/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind()]BankModel model)
        {
            try
            {
                var item = bankService.GetById(model.Id);
                item.Name = model.Name;
                item.FullName = model.FullName;
                item.Address = model.Adress;
                item.City = model.City;
                item.CorrespondingAccount = model.CorrespondingAccount;
                item.EDRPOU = model.EDRPOU;
                item.IsGroup = model.IsGroup;
                item.ParentId = model.ParentId;
                item.Phones = model.Phones;
                item.Rate = model.Rate;
                item.RateSource = model.RateSource;
                bankService.Update(item);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to save changes. Details: {ex.Message}");
                return View(model);
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new BankModel();
            try
            {
                var item = bankService.GetById(id);
                Mapper.Initialize(p => p.CreateMap<BankDTO, BankModel>());
                model = Mapper.Map<BankDTO, BankModel>(item);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to get item to delete. Details: {ex.Message}");
            }
            return View(model);
        }

        // POST: Bank/Delete/5
        [HttpPost]
        public ActionResult Delete([Bind()]BankModel model)
        {
            try
            {
                bankService.Delete(model.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Unable to delete item. Details: {ex.Message}");
                return View(model);
            }
        }

        public new void Dispose()
        {
            bankService.Dispose();
        }
    }
}
