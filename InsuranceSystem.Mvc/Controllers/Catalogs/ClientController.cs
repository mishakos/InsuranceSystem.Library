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
    public class ClientController : Controller
    {
        private IClientService _service;
        public ClientController(IClientService service)
        {
            _service = service;
        }
        // GET: Client
        public async Task<ActionResult> Index()
        {
            var clients = Mapper.Map<List<ClientDTO>, List<ClientModel>>(await _service.GetAllAsync());
            return View(clients);
        }

        // GET: Client/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = Mapper.Map<ClientDTO, ClientModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            var model = new ClientModel();
            return View(model);
        }

        // POST: Client/Create
        [HttpPost]
        public async Task<ActionResult> Create(ClientModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientDto = Mapper.Map<ClientModel, ClientDTO>(model);
                    await _service.InsertAsync(clientDto);
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

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = Mapper.Map<ClientDTO, ClientModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, ClientModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var clientDto = await _service.GetByIdAsync(id);
                    clientDto.BancAccountId = model.BancAccountId;
                    clientDto.EDRPOU = model.EDRPOU;
                    clientDto.FactAddressId = model.FactAdressId;
                    clientDto.FullName = model.FullName;
                    clientDto.IsDelete = model.IsDelete;
                    clientDto.IsGroup = model.IsGroup;
                    clientDto.ITN = model.ITN;
                    clientDto.LegalAddressId = model.LegalAdressId;
                    clientDto.Name = model.Name;
                    clientDto.ParentId = model.ParentId;
                    await _service.UpdateAsync(clientDto);
                    return RedirectToAction("Index");
                }
                else
                    return View(model);                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = Mapper.Map<ClientDTO, ClientModel>(await _service.GetByIdAsync(id));
            return View(model);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, ClientModel model)
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
