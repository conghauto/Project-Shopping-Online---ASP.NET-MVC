using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.DAO
{
    public class AdminDao
    {
        OnlineShopDbContext db = null;

        public object Encryptor { get; private set; }

        public AdminDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Admin enity)
        {
            db.Admins.Add(enity);
            db.SaveChanges();
            return enity.ID;
        }
        public bool Update(Admin entity)
        {
            try
            {
                var admin = db.Admins.Find(entity.ID);
                admin.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    admin.Password = entity.Password;
                }
                admin.Phone = entity.Phone;
                admin.Address = entity.Address;
                admin.Email = entity.Email;
                admin.ModifedBy = entity.ModifedBy;
                db.SaveChanges();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public IEnumerable<Admin> ListAllPaging(string searchString,int page,int pageSize)
        {
            IQueryable<Admin> model = db.Admins;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page,pageSize);
        }
        public Admin ViewDetail(int id)
        {
            return db.Admins.Find(id);
        }
        public Admin GetByID(string userName)
        {
            return db.Admins.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName,string passWord)
        {
            var result = db.Admins.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }else
            {
                if (result.Status == false)
                    return -1;
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
       
        }
        public bool Delete(int id)
        {
            try
            {
                var admin = db.Admins.Find(id);
                db.Admins.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public bool ChangeStatus(int id)
        {
            var admin = db.Admins.Find(id);
            admin.Status = !admin.Status;
            db.SaveChanges();
            return admin.Status;
        }
    }
}
