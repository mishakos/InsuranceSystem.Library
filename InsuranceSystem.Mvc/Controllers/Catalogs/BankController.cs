using DevExpress.Web.Mvc;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Catalogs;
using InsuranceSystem.BLL.Interfaces.Catalogs;
using InsuranceSystem.BLL.Services.Catalogs;
using InsuranceSystem.Common;
using InsuranceSystem.MVC.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using InsuranceSystem.Mvc.App_Start;

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
        public ActionResult Index()
        {
            return View();
        }

        private void PopulateDropDownSearchParam()
        {
            ViewData["SearchParam"] = new SelectList(new Dictionary<string, string>
            {
                [nameof(BankModel.EDRPOU)] = nameof(BankModel.EDRPOU),
                [nameof(BankModel.MFO)] = nameof(BankModel.MFO),
                [nameof(BankModel.Adress)] = nameof(BankModel.Adress),
                [nameof(BankModel.City)] = nameof(BankModel.City),
                [nameof(BankModel.FullName)] = nameof(BankModel.FullName),
                [nameof(BankModel.ParentId)] = nameof(BankModel.ParentId),
                [nameof(BankModel.Phones)] = nameof(BankModel.Phones),
                [nameof(BankModel.Rate)] = nameof(BankModel.Rate),
                [nameof(BankModel.RateSource)] = nameof(BankModel.RateSource)
            }, "Key", "Value");
        }

        private async Task<IEnumerable<BankDTO>> FindItems(string searchParam, string searchString, int page, int pageSize)
        {
            var result = new List<BankDTO>();
            switch (searchParam)
            {
                case nameof(BankModel.EDRPOU):
                    result = await bankService.GetByEDRPOUAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.MFO):
                    result = await bankService.GetByMFOAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.Adress):
                    result = await bankService.GetByAddressAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.City):
                    result = await bankService.GetByCityAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.FullName):
                    result = await bankService.GetByFullNameAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.ParentId):
                    var id = int.Parse(searchString);
                    result = await bankService.GetByParentId(id, page, pageSize);
                    break;
                case nameof(BankModel.Phones):
                    result = await bankService.GetByPhonesAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.Rate):
                    result = await bankService.GetByRateAsync(searchString, page, pageSize);
                    break;
                case nameof(BankModel.RateSource):
                    result = await bankService.GetByRateSource(searchString, page, pageSize);
                    break;
                default:
                    result = await bankService.GetPagedAllAsync(page, pageSize);
                    break;
            }

            return result;

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


        [ValidateInput(false)]
        public async Task<ActionResult> GridViewPartial()
        {
            List<BankModel> model = await GetBanksPage();
            return PartialView("~/Views/Bank/_GridViewPartial.cshtml", model);
        }

        private static List<BankModel> MapBankDTOBankModel(IEnumerable<BankDTO> items)
        {
            return (from p in items
                    select new BankModel()
                    {
                        Adress = p.Address,
                        City = p.City,
                        CorrespondingAccount = p.CorrespondingAccount,
                        DateCreate = p.DateCreate,
                        EDRPOU = p.EDRPOU,
                        FullName = p.FullName,
                        Id = p.Id,
                        IsDelete = p.IsDelete,
                        IsGroup = p.IsGroup,
                        MFO = p.MFO,
                        ModifiedDate = p.ModifiedDate,
                        Name = p.Name,
                        ParentId = p.ParentId,
                        ParentName = p.ParentName,
                        Phones = p.Phones,
                        Rate = p.Rate,
                        RateSource = p.RateSource
                    }).ToList();
        }

        public async Task<ActionResult> GridViewPagingAction(GridViewPagerState pager)
        {
            List<BankModel> model = await GetBanksPage(pager.PageIndex, pager.PageSize);
            return PartialView("~/Views/Bank/_GridViewPartial.cshtml", model);
        }

        private async Task<List<BankModel>> GetBanksPage(int pageIndex = 0, int PageSize = 10)
        {
            var items = await bankService.GetPagedAllAsync(pageIndex + 1, PageSize);
            var model = MapBankDTOBankModel(items);
            return model;
        }
    }
}
