namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HangSanXuat")]
    public partial class HangSanXuat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HangSanXuat()
        {
            DienThoais = new HashSet<DienThoai>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaHSX { get; set; }

        [Display(Name = "Tên hãng xuất")]
        [StringLength(50)]
        public string TenHSX { get; set; }
        [Display(Name = "Liên hệ")]
        [StringLength(200)]
        public string LienHe { get; set; }
        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DienThoai> DienThoais { get; set; }
    }
}
