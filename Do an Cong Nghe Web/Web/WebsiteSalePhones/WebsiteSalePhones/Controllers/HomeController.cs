using Model.EF;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebsiteSalePhones.Common;
using WebsiteSalePhones.Models;

namespace WebsiteSalePhones.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult Index()
        {

            return View();
        }
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }
    }
}