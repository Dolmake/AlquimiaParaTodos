using AlquimiaParaTodos.DAL;
using AlquimiaParaTodos.Models;
using AlquimiaParaTodos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquimiaParaTodos.Controllers
{
    public class ShoppingCartController : Controller
    {
        AlquimiaParaTodosDBContext dbContext = new AlquimiaParaTodosDBContext();
        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View(shoppingCartViewModel);
        }

        // GET: /MiniCart/
        public ActionResult MiniCart()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View("MiniCart",shoppingCartViewModel);
        }

       
        // AJAX: /ShoppingCart/AddToCart/5
        [HttpPost]
        public ActionResult AddToCart(int id, int amount)
        {
            // Retrieve the album from the database
            var addedProduct = dbContext.Products
                .Single(product => product.ID == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            amount = amount < 1 ? 1 : amount;
            for (int i = 0; i < amount;++i )
                cart.AddToCart(addedProduct);

            //// Go back to the main store page for more shopping
            //return RedirectToAction("Index");

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(addedProduct.Title) +
                    " has been added from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount() 
            };
            return Json(results);
        }

        // AJAX: /ShoppingCart/UpdateCart
        [HttpPost]
        public ActionResult UpdateCart()
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            return View("MiniCartRows", shoppingCartViewModel);
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the item to display confirmation
            var product =  dbContext.Carts
                .Single(item => item.ID == id);
            string itemName = product == null ? "NONE " : product.Item.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(itemName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

	}
}