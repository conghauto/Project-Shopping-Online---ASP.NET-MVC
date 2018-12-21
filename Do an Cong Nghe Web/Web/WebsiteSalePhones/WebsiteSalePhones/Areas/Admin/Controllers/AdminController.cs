using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using WebsiteSalePhones.Common;

namespace WebsiteSalePhones.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin/Admin
        public ActionResult Index(string searchString,int page=1,int pageSize=10)
        {
            var dao = new AdminDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Model.EF.Admin admin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(admin.Password);
                admin.Password = encryptedMd5Pas;
                long id = dao.Insert(admin);
                if (id > 0)
                {
                    SetAlert("Thêm Admin thành công", "success");
                    return RedirectToAction("Index", "Admin");
                }else
                {
                    ModelState.AddModelError("", "Thêm admin không thành công.");
                }
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var admin = new AdminDao().ViewDetail(id);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Edit(Model.EF.Admin admin)
        {
            if (ModelState.IsValid)
            {
                var dao = new AdminDao();
                if (!string.IsNullOrEmpty(admin.Password))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(admin.Password);
                    admin.Password = encryptedMd5Pas;
                }

                var result = dao.Update(admin);
                if (result)
                {
                    SetAlert("Cập nhật thông tin Admin thành công", "success");

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật admin không thành công.");
                }
            }
            return View("Index");
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new AdminDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = new AdminDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}