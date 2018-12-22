using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteSalePhones.Models
{
    public class UserDao
    {
        OnlineShopDbContext db = null;

        public object Encryptor { get; private set; }

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public int Insert(KhachHang enity)
        {
            db.KhachHangs.Add(enity);
            db.SaveChanges();
            return enity.MaKH;
        }
      
        public KhachHang GetByID(string userName)
        {
            return db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.KhachHangs.SingleOrDefault(x => x.TaiKhoan == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                   if (result.MatKhau == passWord)
                        return 1;
                    else
                        return -2;
            }

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