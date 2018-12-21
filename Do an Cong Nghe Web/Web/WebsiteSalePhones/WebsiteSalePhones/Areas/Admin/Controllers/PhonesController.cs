using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteSalePhones.Areas.Admin.Controllers
{
    public class PhonesController : BaseController
    {
        // GET: Admin/Phones
        public ActionResult Index(int page=1,int pageSize=10)
        {
            var dao = new PhoneDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(DienThoai model)
        {
            if (ModelState.IsValid)
            {
                var phone = new PhoneDao();
                int id = phone.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Phones");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm sản phẩm không thành công.");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = new PhoneDao().GetById(id);
            SetViewBag(dt.MaHSX);
            return View(dt);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DienThoai model)
        {
            if (ModelState.IsValid)
            {
                var phone = new PhoneDao();
                var result = phone.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thông tin Sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Phones");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công.");
                }
            }
            SetViewBag(model.MaHSX);
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new PhoneDao().Delete(id);
            return RedirectToAction("Index", "Phones");
        }
        public void SetViewBag(int? selectedId = null)
        {
            var dao =new CategoryDao();
            ViewBag.MaHSX = new SelectList(dao.ListAll(), "MaHSX", "TenHSX",selectedId);
        }
    }
}