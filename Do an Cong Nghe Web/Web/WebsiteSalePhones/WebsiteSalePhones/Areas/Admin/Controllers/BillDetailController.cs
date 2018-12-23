using Model.DAO;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteSalePhones.Areas.Admin.Controllers
{
    public class BillDetailController : BaseController
    {
        OnlineShopDbContext db = new OnlineShopDbContext();
        // GET: Admin/BillDetail
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult BillDetail(int MaDH = 0)
        {
            List<ChiTietDonHang> detail = db.ChiTietDonHangs.Where(n => n.MaDH == MaDH).ToList();

            return View(detail.OrderBy(n => n.SoLuong).ToPagedList(1, 6));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new BillDetailDao().Delete(id);
            return RedirectToAction("BillDetail","BillDetail");
        }
    }
}