using Model.DAO;
using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteSalePhones.Areas.Admin.Controllers
{
    public class BillController : BaseController
    {
        // GET: Admin/Bill
        OnlineShopDbContext db = new OnlineShopDbContext();
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BillDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
      
   
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bill = new BillDao().ViewDetail(id);
            return View(bill);
        }
        [HttpPost]
        public ActionResult Edit(DonHang bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDao();
               

                var result = dao.Update(bill);
                if (result)
                {
                    SetAlert("Cập nhật thông tin người nhận hóa đơn thành công.", "success");

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thông tin thất bại.");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new BillDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}