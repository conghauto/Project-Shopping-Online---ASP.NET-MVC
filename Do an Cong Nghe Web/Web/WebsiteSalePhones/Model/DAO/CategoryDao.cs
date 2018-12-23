using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Model.DAO
{
    public class CategoryDao
    {
        OnlineShopDbContext db = null;
        public CategoryDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<HangSanXuat> ListAll()
        {
            return db.HangSanXuats.Where(x => x.TrangThai == true).ToList();
        }
        public List<HangSanXuat> ListLimit()
        {
            return db.HangSanXuats.Where(x => x.TrangThai == true).Take(9).ToList();
        }

        public HangSanXuat GetById(int id)
        {
            return db.HangSanXuats.Find(id);
        }
        public IEnumerable<HangSanXuat> ListAllPaging(int page, int pageSize)
        {
            return db.HangSanXuats.OrderBy(x => x.MaHSX).ToPagedList(page, pageSize);
        }
        public List<string> ListName(string keyword)
        {
            return db.HangSanXuats.Where(x => x.TenHSX.Contains(keyword)).Select(x => x.TenHSX).ToList();
        }
        public int Insert(HangSanXuat enity)
        {
            db.HangSanXuats.Add(enity);
            db.SaveChanges();
            return enity.MaHSX;
        }
        public bool Update(HangSanXuat entity)
        {
            try
            {
                var phone = db.HangSanXuats.Find(entity.MaHSX);
                phone.MaHSX = entity.MaHSX;
                phone.TenHSX = entity.TenHSX;
                phone.LienHe= entity.LienHe;
                phone.TrangThai= entity.TrangThai;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var phone = db.HangSanXuats.Find(id);
                db.HangSanXuats.Remove(phone);
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
