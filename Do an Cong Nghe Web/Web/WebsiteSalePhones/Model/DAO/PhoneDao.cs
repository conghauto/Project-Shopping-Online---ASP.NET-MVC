using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
   public class PhoneDao
    {
        OnlineShopDbContext db = null;
        public PhoneDao()
        {
            db = new OnlineShopDbContext();
        }
        public DienThoai GetById(int id)
        {
            return db.DienThoais.Find(id);
        }
        public IEnumerable<DienThoai> ListAllPaging(int page, int pageSize)
        {
            return db.DienThoais.OrderBy(x=>x.MaDT).ToPagedList(page, pageSize);
        }
        public List<string> ListName(string keyword)
        {
            return db.DienThoais.Where(x => x.TenDT.Contains(keyword)).Select(x => x.TenDT).ToList();
        }
        public int Insert (DienThoai enity)
        {
            db.DienThoais.Add(enity);
            db.SaveChanges();
            return enity.MaDT;
        }
        public bool Update(DienThoai entity)
        {
            try
            {
                var phone = db.DienThoais.Find(entity.MaDT);
                phone.TenDT = entity.TenDT;
                phone.GiaBan = entity.GiaBan;
                phone.GioiThieu = entity.GioiThieu;
                phone.MoTaChiTiet = entity.MoTaChiTiet;
                phone.AnhBia = entity.AnhBia;
                phone.NgayCapNhat = entity.NgayCapNhat;
                phone.SoLuongTon = entity.SoLuongTon;
                phone.MaHSX = entity.MaHSX;
                phone.Moi = entity.Moi;

                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var phone = db.DienThoais.Find(id);
                db.DienThoais.Remove(phone);
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
