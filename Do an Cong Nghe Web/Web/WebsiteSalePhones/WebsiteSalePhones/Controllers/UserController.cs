using BotDetect.Web.Mvc;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSalePhones.Models;

namespace WebsiteSalePhones.Controllers
{
    
    public class UserController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [SimpleCaptchaValidation("CaptchaCode", "registerCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.KhachHangs.Count(x => x.TaiKhoan == model.TaiKhoan) > 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }
                else if (db.KhachHangs.Count(x => x.Email == model.Email) > 0)
                {
                    ModelState.AddModelError("", "Email đã tồn tại.");
                }
                else
                {
                    var kh = new KhachHang();
                    kh.TaiKhoan = model.TaiKhoan;
                    kh.MatKhau = model.MatKhau;
                    kh.XacNhanMK = model.XacNhanMK;
                    kh.HoTen = model.HoTen;
                    kh.Email = model.Email;
                    kh.DiaChi = model.DiaChi;
                    kh.DienThoai = model.DienThoai;
                    kh.GioiTinh = model.GioiTinh;
                    kh.NgaySinh = model.NgaySinh;

                    //Insert data in table KhachHang
                    var result=db.KhachHangs.Add(kh);
                    if (result!=null)
                    {
                        ViewBag.Success = "Đăng ký thành công.";
                        model = new RegisterModel();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Đăng ký thất bại.");
                    }
                    //Save info in Database
                    db.SaveChanges();
                }
            }
            return View(model);
        }
    }
}