using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
