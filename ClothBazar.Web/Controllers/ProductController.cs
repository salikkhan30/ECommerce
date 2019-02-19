using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothBazar.Entities;
using ClothBazar.Service;
using Newtonsoft.Json;

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
        public PartialViewResult ProductListView(string search)
        {
            var pro = this.service.GetProduct();

            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                pro = pro.Where(x => x.Name == search).ToList();

            return PartialView(pro);
        }

        // GET: Product
        public JsonResult GetAll(string search)
        {
            var pro = this.service.GetProduct();
            
            if (!string.IsNullOrEmpty(search) && !string.IsNullOrWhiteSpace(search))
                pro = pro.Where(x => x.Name == search).ToList();

            var json = JsonConvert.SerializeObject(pro);

            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // GET: Product/Create
        [HttpGet]
        public PartialViewResult ProductCreateView()
        {
            return PartialView();
        }

        //POST: Product/Create
        [HttpPost]
        public RedirectToRouteResult CreateProduct(Product dtoObject)
        {
            // TODO: Add insert logic here
            this.service.SaveProduct(dtoObject);

            return RedirectToAction("ProductListView");
        }

        // GET: Product/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var pro = this.service.GetSingleProduct(id);

            return PartialView(pro);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product dtoObject)
        {
            try
            {
                // TODO: Add update logic here
                this.service.UpdateProduct(dtoObject);

                return RedirectToAction("ProductListView");
            }
            catch
            {
                return View();
            }
        }


        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var pro = this.service.GetSingleProduct(id);

                // TODO: Add update logic here
                this.service.DeleteProduct(pro);

                return RedirectToAction("ProductListView");
            }
            catch
            {
                return View();
            }
        }
    }
}
