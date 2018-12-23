using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteSalePhones.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new CategoryDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HangSanXuat model)
        {
            if (ModelState.IsValid)
            {
                var phone = new CategoryDao();
                int id = phone.Insert(model);
                if (id > 0)
                {
                    SetAlert("Thêm hãng sản xuất thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm hãng sản xuất không thành công.");
                }
            }
    
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dt = new CategoryDao().GetById(id);
           
            return View(dt);
        }
        [HttpPost]
        public ActionResult Edit(HangSanXuat model)
        {
            if (ModelState.IsValid)
            {
                var phone = new CategoryDao();
                var result = phone.Update(model);
                if (result)
                {
                    SetAlert("Cập nhật thông tin hãng sản xuất thành công", "success");
                    return RedirectToAction("Index", "Phones");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật hãng sản xuất không thành công.");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index", "Category");
        }
    }
}