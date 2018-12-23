using BotDetect.Web.Mvc;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteSalePhones.Common;
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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonConstant.USER_SESSION] = null;
            return Redirect("/");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.TaiKhoan, Encryptor.MD5Hash(model.MatKhau));
                if (result == 1)
                {
                    //Gán Session
                    var user = dao.GetByID(model.TaiKhoan);
                    var userSession = new UserLogin();
                    userSession.UserName = user.TaiKhoan;
                    userSession.UserID = user.MaKH;
                    
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản bị khóa.");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng.");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }
            else
            {

            }
            return View(model);
        }
        [HttpPost]
    public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.KhachHangs.Count(x => x.TaiKhoan == model.TaiKhoan) > 0)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại.");
                }
                //else if (db.KhachHangs.Count(x => x.Email == model.Email) > 0)
                //{
                //    ModelState.AddModelError("", "Email đã tồn tại.");
                //}
                else
                {
                    var kh = new KhachHang();
                    kh.TaiKhoan = model.TaiKhoan;
                    kh.MatKhau = Encryptor.MD5Hash(model.MatKhau);
                    kh.XacNhanMK = Encryptor.MD5Hash(model.XacNhanMK);
                    kh.HoTen = model.HoTen;
                    //kh.Email = model.Email;
                    //kh.DiaChi = model.DiaChi;
                    //kh.DienThoai = model.DienThoai;
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