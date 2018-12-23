using Model.DAO;
using Model.EF;
using Model.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Model.DAO
{
    public class BillDetailDao
    {
        OnlineShopDbContext db = null;

        public BillDetailDao()
        {
            db = new OnlineShopDbContext();
        }
        public bool Update(ChiTietDonHang entity)
        {
            try
            {
                var bill = db.ChiTietDonHangs.Find(entity.MaDH);
                bill.SoLuong = entity.SoLuong;
                bill.DonGia = entity.DonGia;

                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public IEnumerable<ChiTietDonHang> ListAllPaging(int page, int pageSize)
        {
            return db.ChiTietDonHangs.OrderBy(x => x.SoLuong).ToPagedList(page, pageSize);
        }


        public bool Delete(int id)
        {
            
            
            try
            {
                var bill = db.ChiTietDonHangs.SingleOrDefault(x => x.MaDH == id);
                db.ChiTietDonHangs.Remove(bill);
                db.SaveChanges();
                return true;
            }
            catch
            {
                
                return false;
            }
        }
        public List<BillViewModel>ListDetail(string name)
        {
            try
            {
                var model = (from a in db.ChiTietDonHangs
                             join b in db.DonHangs on a.MaDH equals b.MaDH
                             join c in db.DienThoais on a.MaDT equals c.MaDT
                             where b.NguoiNhan == name
                             select new
                             {
                                 MaDH = a.MaDH,
                                 MaDT = a.MaDT,
                                 MaKH=b.MaKH,
                                 TenDT = c.TenDT,
                                 NguoiNhan = b.NguoiNhan,
                                 SoLuong = a.SoLuong,
                                 DonGia = a.DonGia,
                             }).AsEnumerable().Select(x => new BillViewModel()
                             {
                                 MaDH = x.MaDH,
                                 MaDT = x.MaDT,
                                 MaKH = x.MaKH,
                                 TenDT = x.TenDT,
                                 NguoiNhan = x.NguoiNhan,
                                 SoLuong = x.SoLuong,
                                 DonGia = x.DonGia
                             });

                return model.ToList();
            }catch
            {
                return null;
            }
        }
    }
}
