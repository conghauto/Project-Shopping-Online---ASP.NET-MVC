using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class BillDao
    {
        OnlineShopDbContext db = null;

        public BillDao()
        {
            db = new OnlineShopDbContext();
        }
        public int Insert(DonHang enity)
        {
            db.DonHangs.Add(enity);
            db.SaveChanges();
            return enity.MaDH;
        }
        public bool Update(DonHang entity)
        {
            try
            {
                var bill = db.DonHangs.Find(entity.MaDH);
                bill.DaThanhToan = entity.DaThanhToan;
                bill.TinhTrangGH = entity.TinhTrangGH;
                bill.NgayDat = entity.NgayDat;
                bill.NgayGiao = entity.NgayGiao;
                bill.NguoiNhan = entity.NguoiNhan;
                bill.Email = entity.Email;
                bill.SoDT = entity.SoDT;
                bill.DiaChi = entity.DiaChi;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<DonHang> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<DonHang> model = db.DonHangs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.NguoiNhan.Contains(searchString) || x.DiaChi.Contains(searchString));
            }

            return model.OrderByDescending(x => x.NgayDat).ToPagedList(page, pageSize);
        }
        public DonHang ViewDetail(int id)
        {
            return db.DonHangs.Find(id);
        }
        public DonHang GetByID(string userName)
        {
            return db.DonHangs.SingleOrDefault(x => x.NguoiNhan == userName);
        }
        public bool Delete(int id)
        {
            try
            {
                var bill = db.DonHangs.Find(id);
                db.DonHangs.Remove(bill);
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