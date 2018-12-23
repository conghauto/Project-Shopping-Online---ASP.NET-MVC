namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaKH { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [StringLength(50)]
        [Display(Name = "Xác nhận mật khẩu")]
        public string XacNhanMK { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(15)]
        [Display(Name = "Số DT")]
        public string DienThoai { get; set; }

        [StringLength(3)]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime? NgaySinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
