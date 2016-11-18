using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using InsuranceSystem.BLL.DTO.Documents;
using InsuranceSystem.BLL.Services.Documents;
using InsuranceSystem.MVC.Models.Documents;

namespace InsuranceSystem.Mvc.Controllers.Documents
{
    public class PostBlankController : Controller
    {
        PostBlankService postBlankService;
        public PostBlankController()
        {
            postBlankService = new PostBlankService();
        }


        // GET: PostBlank
        public ActionResult Index()
        {
            var items = postBlankService.GetPostBlanks();
            Mapper.Initialize(p => p.CreateMap<PostBlankDTO, PostBlankModel>());
            var model = Mapper.Map<IEnumerable<PostBlankDTO>, List<PostBlankModel>>(items);
            return View(model);
        }

        // GET: PostBlank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostBlank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostBlank/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostBlank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostBlank/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PostBlank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostBlank/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            postBlankService.Dispose();
        }
    }
}
