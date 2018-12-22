using Model.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSalePhones.Common;
using WebsiteSalePhones.Models;
using System.Web.Script.Serialization;
using Model.EF;
using System.Configuration;
using Common;
using System.Net.Mail;

namespace WebsiteSalePhones.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private MailMessage mail;
        private SmtpClient smtp;
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
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CommonConstant.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string shipName, string address, string phoneNumber, string email)
        {
            var order = new DonHang();
            order.NgayDat = DateTime.Now;
            order.NguoiNhan = shipName;
            order.DiaChi = address;
            order.SoDT = phoneNumber;
            order.Email = email;

            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CommonConstant.CartSession];
                var detailDao = new OrderDetailDao();
                decimal total = 0;
                foreach (var item in cart)
                {
                    var orderDetail = new ChiTietDonHang();

                    orderDetail.MaDT = item.DienThoai.MaDT;
                    orderDetail.MaDH = id;
                    orderDetail.DonGia = item.DienThoai.GiaBan;
                    orderDetail.SoLuong = item.Quantity;

                    detailDao.Insert(orderDetail);
                    total += (item.DienThoai.GiaBan.GetValueOrDefault(0) * item.Quantity);
                }
                //string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/neworder.html"));

                //content = content.Replace("{{CustomerName}}", shipName);
                //content = content.Replace("{{Phone}}", phoneNumber);
                //content = content.Replace("{{Email}}", email);
                //content = content.Replace("{{Address}}", address);
                //content = content.Replace("{{Total}}", total.ToString("N0"));
                //var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

                string body = " Thông tin đơn hàng mới từ khách hàng: " + shipName + "<br/>" +
                           " Điện thoại: " + phoneNumber + "<br/>" +
                           " Email: " + email + "<br/>" +
                           " Địa chỉ: " + address + "<br/>" +
                           " Trị giá: " + total.ToString("N0") + "<br/>";
                SendMail(email, body);
                SendMail("dpsg.webapp@gmail.com", body);

                //new MailHelper().SendMail(email, "Đơn hàng mới từ OnlineShop", content);
                //new MailHelper().SendMail(toEmail, "Đơn hàng mới từ OnlineShop", content);

            }
            catch
            {
                return Redirect("/loi-thanh-toan");
            }
            return Redirect("/hoan-thanh");
        }
        public ActionResult Sucess()
        {
            return View();
        }
        public ActionResult Error(string email)
        {
            return View();
        }
        public void SendMail(string name,string body)
        {
            mail = new MailMessage();
            mail.To.Add(name);
            mail.From = new MailAddress("dpsg.webapp@gmail.com");
            mail.Subject = "sub";

            mail.Body = body;

            mail.IsBodyHtml = true;
            smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("dpsg.webapp@gmail.com", "0935270629"); // **use valid credentials**
            smtp.Port = 587;

            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}