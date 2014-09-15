using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlquimiaParaTodos.Models;
using AlquimiaParaTodos.DAL;

namespace AlquimiaParaTodos.Controllers
{
    public class ShopItemController : Controller
    {
        private AlquimiaParaTodosDBContext db = new AlquimiaParaTodosDBContext();


        // GET: /ShopItem/Show/5
        public ActionResult Show(int? id)
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

            Category activeCategory = product.Categories.ElementAt(0);

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.ActiveCategory = activeCategory;
            ViewBag.CategoriesCount = product.Categories.Count();

            return View(product);
        }

        [HttpPost()]
        public ActionResult ShowDetails(int? id)
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

            Category activeCategory = product.Categories.Count() > 0 ? product.Categories.ElementAt(0) : null;

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.ActiveCategory = activeCategory;
            ViewBag.CategoriesCount = product.Categories.Count();

            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
