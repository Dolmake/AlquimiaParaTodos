using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlquimiaParaTodos.DAL;
using AlquimiaParaTodos.Models;

namespace AlquimiaParaTodos
{
    public class SearchController : Controller
    {
        private AlquimiaParaTodosDBContext db = new AlquimiaParaTodosDBContext();

        // GET: Search
        public ActionResult Index()
        {
            //return View(db.Products.ToList());
            return View();
        }

        public ActionResult Find(string text)
        {
            return View(FindByText(text));          
        }


        private List<Product> FindByText(string text)
        {
            
            List<Product> res = null;
            if (string.IsNullOrEmpty(text))
                res = db.Products.ToList();
            else
            {
                var result = from c in db.Products
                             where
                                 c.Title.Contains(text)                             
                             select c;

                res = result.ToList();
            }

            return res;
        }



        // GET: Search/Details/5
        public ActionResult Details(int? id)
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
