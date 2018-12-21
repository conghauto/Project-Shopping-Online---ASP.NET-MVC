using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Model.EF;
using Model.DAO;
using PagedList.Mvc;
using PagedList;

namespace WebsiteSalePhones.Controllers
{
    public class PhoneController : Controller
    {
        // GET: PhoneNewPartial
        OnlineShopDbContext db = new OnlineShopDbContext();
        public PartialViewResult PhoneNew()
        {
            return PartialView(db.DienThoais.Where(n=>n.Moi==true).Take(3).ToList().OrderByDescending(n => n.GiaBan).ToList());
        }
        public PartialViewResult PhoneNew1()
        {
            return PartialView(db.DienThoais.Take(3).ToList().OrderByDescending(n => n.NgayCapNhat).ToList());
        }
        public PartialViewResult PhoneBestSell()
        {
            return PartialView(db.DienThoais.Take(3).ToList().OrderByDescending(n => n.GiaBan).ToList());
        }
        public ViewResult ProductDetail(int MaDT = 0)
        {
            DienThoai phone = db.DienThoais.SingleOrDefault(n => n.MaDT == MaDT);
            if (phone == null)
            {
                //Return Page Error
                Response.StatusCode = 404;
                return null;
            }
            return View(phone);
        }
        public JsonResult ListName(string q)
        {
            var data = new PhoneDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ResultSearch(FormCollection collection, int?page)
        {
            //string sTuKhoa = Convert.ToString(f["txtKeyword"]);
            string sTuKhoa = Convert.ToString(collection["txtKeyword"]);
            ViewBag.KeyWord = sTuKhoa;
            List<DienThoai> lstResult = db.DienThoais.Where(x => x.TenDT.Contains(sTuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstResult.Count == 0)
            {
                ViewBag.Notify = "Không tìm thấy kết quả.";
                return View(db.DienThoais.OrderBy(x => x.TenDT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Notify = "Đã tìm thấy " + lstResult.Count + " kết quả.";
            return View(lstResult.OrderBy(x => x.TenDT).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult ResultSearch(int? page, string sTuKhoa)
        {
            //string sTuKhoa = Convert.ToString(f["txtKeyword"]);

            ViewBag.KeyWord = sTuKhoa;
            List<DienThoai> lstResult = db.DienThoais.Where(x => x.TenDT.Contains(sTuKhoa)).ToList();

            int pageNumber = (page ?? 1);
            int pageSize = 6;
            if (lstResult.Count == 0)
            {
                ViewBag.Notify = "Không tìm thấy kết quả.";
                return View(db.DienThoais.OrderBy(x => x.TenDT).ToPagedList(pageNumber, pageSize));
            }
            ViewBag.Notify = "Đã tìm thấy " + lstResult.Count + " kết quả.";
            return View(lstResult.OrderBy(x => x.TenDT).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult AllProduct(int? page)
        {
            //Tao bien so san pham tren trang
            int pageSize = 6;
            //Tao bien so trang
            int pageNumber = (page ?? 1);
            return View(db.DienThoais.OrderBy(n=>n.GiaBan).ToPagedList(pageNumber, pageSize));
        }

    }
}