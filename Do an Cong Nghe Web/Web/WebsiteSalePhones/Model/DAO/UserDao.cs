using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class UserDao
    {
        OnlineShopDbContext db = null;

        public object Encryptor { get; private set; }

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Update(KhachHang entity)
        {
            try
            {
                var user = db.KhachHangs.Find(entity.MaKH);
                user.MaKH = entity.MaKH;
                user.TaiKhoan= entity.TaiKhoan;
                user.HoTen = entity.HoTen;
                user.MatKhau = entity.MatKhau;
                user.XacNhanMK = entity.XacNhanMK;
                user.GioiTinh = entity.GioiTinh;
                user.Email = entity.Email;
                user.DiaChi = entity.DiaChi;
                user.DienThoai = entity.DienThoai;
                user.NgaySinh = entity.NgaySinh;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<KhachHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<KhachHang> model = db.KhachHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.HoTen.Contains(searchString) || x.TaiKhoan.Contains(searchString));
            }

            return model.OrderByDescending(x => x.MaKH).ToPagedList(page, pageSize);
        }
        public KhachHang ViewDetail(int id)
        {
            return db.KhachHangs.Find(id);
        }
        public KhachHang GetByID(string userName)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == userName);
        }
       
        public bool Delete(int id)
        {
            try
            {
                var user = db.KhachHangs.Find(id);
                db.KhachHangs.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
