using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class BillViewModel
    {
        public int MaDH { get; set; }
        public int MaDT { get; set; }
        public int? MaKH { get; set; }
        public string TenDT { get; set; }
        public string NguoiNhan { get; set; }
        public int? SoLuong { get; set; }

        public decimal? DonGia { get; set; }
    }
}
