namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DienThoai")]
    public partial class DienThoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DienThoai()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaDT { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên điện thoại")]
        public string TenDT { get; set; }
        [Display(Name = "Giá bán")]
        public decimal? GiaBan { get; set; }
        [Display(Name = "Giới thiệu")]
        [AllowHtml]
        public string GioiThieu { get; set; }
        
        [Display(Name = "Mô tả chi tiết")]
        [AllowHtml]
        public string MoTaChiTiet { get; set; }
        [Display(Name = "Ảnh")]
        public string AnhBia { get; set; }
        [Display(Name = "Ngày cập nhật")]
        public DateTime? NgayCapNhat { get; set; }
        [Display(Name = "Số lượng")]
        public int? SoLuongTon { get; set; }
        [Display(Name = "Hãng sản xuất")]
        public int? MaHSX { get; set; }
        [Display(Name = "Mới")]
        public bool Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual HangSanXuat HangSanXuat { get; set; }
    }

    class AllowHtmlAttribute : Attribute
    {
    }
}
