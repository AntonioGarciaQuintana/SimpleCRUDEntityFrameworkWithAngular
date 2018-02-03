using AppStoreWithAngular.EntityFramework;
using AppStoreWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppStoreWithAngular.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getProducts() {
            Dal dal = new Dal();

            List<Product> productList = dal.products.ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult saveProduct(Product product) {
            Dal dal = new Dal();
            dal.products.Add(product);
            dal.SaveChanges();

            List<Product> productList = dal.products.ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getProduct(long idProduct) {
            Dal dal = new Dal();

            Product product = dal.products.Find(idProduct);
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateProduct(Product product)
        {
            Dal dal = new Dal();
            dal.Entry(product).State = System.Data.Entity.EntityState.Modified;
            dal.SaveChanges();

            List<Product> productList = dal.products.ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult deleteProduct(long idProduct)
        {
            Dal dal = new Dal();

            Product product = dal.products.Find(idProduct);
            dal.Entry(product).State = System.Data.Entity.EntityState.Deleted;
            dal.SaveChanges();

            List<Product> productList = dal.products.ToList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }


    }
}