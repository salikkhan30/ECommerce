using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entities;
using ClothBazar.Service;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductService service = new ProductService();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: Product
        public ActionResult GetAll(string search)
        {
            var pro = this.service.GetProduct();
            
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                pro = pro.Where(x => x.Name == search).ToList();

            return PartialView(pro);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var pro = this.service.GetSingleProduct(id);

            return PartialView(pro);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        //POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product dtoObject)
        {
            // TODO: Add insert logic here
            this.service.SaveProduct(dtoObject);

            return PartialView();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
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

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
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
    }
}
