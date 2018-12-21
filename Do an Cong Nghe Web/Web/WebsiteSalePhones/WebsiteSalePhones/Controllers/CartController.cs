using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSalePhones.Common;
using WebsiteSalePhones.Models;
using System.Web.Script.Serialization;

namespace WebsiteSalePhones.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CommonConstant.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Delete(long id)
        {
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];
            sessionCart.RemoveAll(x => x.DienThoai.MaDT == id);
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CommonConstant.CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.DienThoai.MaDT == item.DienThoai.MaDT);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CommonConstant.CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(int productID, int quantity)
    {
        var product = new PhoneDao().GetById(productID);
        var cart = Session[CommonConstant.CartSession];
        if (cart != null)
        {
            var list = (List<CartItem>)cart;
            if (list.Exists(x => x.DienThoai.MaDT == productID))
            {
                foreach (var item in list)
                {
                    if (item.DienThoai.MaDT == productID)
                    {
                        item.Quantity += quantity;
                    }
                }
            }
            else
            {
                //tao moi doi tuong cart item
                var item = new CartItem();
                item.DienThoai = product;
                item.Quantity = quantity;
                list.Add(item);
            }
            //Gan vao Session
            Session[CommonConstant.CartSession] = list;
        }
        else
        {
            //tao moi doi tuong cart item
            var item = new CartItem();
            item.DienThoai = product;
            item.Quantity = quantity;
            var list = new List<CartItem>();
            list.Add(item);
            // Gan vao session
            Session[CommonConstant.CartSession] = list;
        }
        return RedirectToAction("Index");
    }
        public ActionResult Payment()
        {
            return View();
        }
    }
}