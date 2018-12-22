using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
        public int Insert(DonHang order)
        {
            db.DonHangs.Add(order);
            db.SaveChanges();
            return order.MaDH;
        }
    }
}
