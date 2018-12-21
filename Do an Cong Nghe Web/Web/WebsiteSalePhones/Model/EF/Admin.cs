namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {

        public int ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản")]
        public string UserName { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ tên")]
        public string Name { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(12)]
        [Display(Name = "Điện thoại")]
        public string Phone { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        [StringLength(50)]
        [Display(Name = "Người chỉnh sửa")]
        public string ModifedBy { get; set; }
        [Display(Name = "Trạng thái")]
        public bool Status { get; set; }
    }
}
