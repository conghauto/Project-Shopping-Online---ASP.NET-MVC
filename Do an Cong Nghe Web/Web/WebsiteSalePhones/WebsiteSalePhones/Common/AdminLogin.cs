using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebsiteSalePhones
{
    [Serializable]
    public class AdminLogin
    {  
        public int UserID { set; get; }
        public string UserName { set; get; }
    }
}