using AlquimiaParaTodos.DAL;
using AlquimiaParaTodos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AlquimiaParaTodos.Controllers
{
    public class HomeController : Controller
    {

        private AlquimiaParaTodosDBContext db = new AlquimiaParaTodosDBContext();

        protected override IActionInvoker CreateActionInvoker()
        {
            ViewBag.AppDescriptor = Startup.AppDescriptor;
            return base.CreateActionInvoker();
        }

        public ActionResult Index()
        {
            ViewBag.ActiveItem = 0;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ActiveItem = 2;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.ActiveItem = 3;
            return View();
        }

        //public ActionResult Home()
        //{
        //    int newStuffID = 13; 
        //    Category activeCategory = db.Categories.Single(cat => cat.ID == newStuffID);
            
        //    ViewBag.Category = activeCategory;
        //    ViewBag.CategoryProductsCount = activeCategory.Products.Count();

        //    return View(db.Categories.ToList());
        //}

        public ActionResult Home(int? id)
        {
            int? newStuffID = 13;
            if (id != null)
                newStuffID= id;

            Category activeCategory = db.Categories.Single(cat => cat.ID == newStuffID);

            ViewBag.Category = activeCategory;
            ViewBag.CategoryProductsCount = activeCategory.Products.Count();
            ViewBag.ActiveItem = 1;

            return View(db.Categories.ToList());
        }

        public ActionResult ShopItem(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.ActiveCategory = product.Categories.ToList().ElementAt(0);

            return View(product);
        }
    }
}