using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entities;
using ClothBazar.Service;

namespace ClothBazar.Web.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryService service = new CategoryService();

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            var cat = this.service.GetCategory();

            return View(cat);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category dtoObject)
        {
            try
            {
                // TODO: Add insert logic here
                this.service.SaveCategory(dtoObject);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = this.service.GetSingleCategory(id);
            if (cat != null)
                return View(cat);
            else
                return RedirectToAction("Index");
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category dtoObject)
        {
            try
            {
                // TODO: Add update logic here
                this.service.UpdateCategory(dtoObject);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(dtoObject);
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var cat = this.service.GetSingleCategory(id);
            if (cat != null)
                return View(cat);
            else
                return RedirectToAction("Index");
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Category dtoObject)
        {
            try
            {
                // TODO: Add delete logic here
                this.service.DeleteCategory(dtoObject);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
