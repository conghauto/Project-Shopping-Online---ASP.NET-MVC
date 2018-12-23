namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "Mã DH")]
        public int MaDH { get; set; }

        [StringLength(50)]
        [Display(Name = "Thanh toán")]
        public string DaThanhToan { get; set; }
        [Display(Name = "Tình trạng")]
        public int? TinhTrangGH { get; set; }
        [Display(Name = "Ngày đặt")]
        public DateTime? NgayDat { get; set; }
        [Display(Name = "Ngày giao")]
        public DateTime? NgayGiao { get; set; }
        [Display(Name = "Mã KH")]
        public int? MaKH { get; set; }

        [StringLength(100)]
        [Display(Name = "Người nhận")]
        public string NguoiNhan { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(12)]
        [Display(Name = "Số DT")]
        public string SoDT { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
