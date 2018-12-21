using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteSalePhones.Models
{
    [Serializable]
    public class CartItem
    {
      
        public DienThoai DienThoai { get; set; }
        public int Quantity{ get; set; }
    }
}