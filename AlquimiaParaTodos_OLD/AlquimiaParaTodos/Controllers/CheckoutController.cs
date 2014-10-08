using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlquimiaParaTodos.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        //
        // GET: /AddressAndPayment/
        public ActionResult AddressAndPayment()
        {
            return View();
        }
	}
}