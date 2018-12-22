using Model.DAO;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteSalePhones.Controllers
{
    public class PhoneCategoryController : Controller
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: PhoneCategory
        public PartialViewResult Navigation()
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int MaHSX= int.Parse(db.HangSanXuats.ToList().ElementAt(0).MaHSX.ToString());
            //Tạo 1 viewbag gán sách theo Nhà xuất bản đầu tiên trong csdl
            ViewBag.DienThoaiTheoHSX = db.DienThoais.Where(n => n.MaHSX == MaHSX).ToList();
            return PartialView(new CategoryDao().ListLimit());
        }
        public ViewResult AllPhoneCategory()
        {
            return View(new CategoryDao().ListAll());
        }
        public ViewResult ShowPhoneType(int MaHSX=0)
        {
            HangSanXuat nxb = db.HangSanXuats.SingleOrDefault(n => n.MaHSX == MaHSX);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            ViewBag.HangSanXuat = nxb.TenHSX;
            //Hiển thị sách theo Nhà xuất bản
            List<DienThoai> lstPhone = db.DienThoais.Where(n => n.MaHSX == MaHSX).ToList();
            if (lstPhone.Count == 0)
            {
                ViewBag.Phone = "Không có sản phẩm thuộc danh mục này";
            }
            //Gán danh sách nhà xuất bản
            ViewBag.lstHangSanXuat = db.HangSanXuats.ToList();
     
            return View(lstPhone.OrderBy(n => n.GiaBan).ToPagedList(1, 6));
        }
    }
}