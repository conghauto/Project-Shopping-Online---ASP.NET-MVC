using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteSalePhones.Models
{
    public class RegisterModel
    {
        [Key]
        public int MaKH { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Yêu cầu nhập tên đăng nhập.")]
        public string TaiKhoan { get; set; }
        [Display(Name = "Mật khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Mật khẩu phải có ít nhất 6 ký tự.")]
        public string MatKhau { get; set; }
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Xác nhận mật khẩu không đúng.")]
        public string XacNhanMK { get; set; }
        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ tên.")]
        public string HoTen { get; set; }

        //[Display(Name = "Email")]
        //[Required(ErrorMessage = "Yêu cầu nhập email.")]
        //[RegularExpression((@"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$"), ErrorMessage = "{0} không hợp lệ")]

        //public string Email{ get; set; }
        //[Display(Name = "Địa chỉ")]
        //public string DiaChi{ get; set; }
        //[Display(Name = "Điện thoại")]
        //public string DienThoai { get; set; }
        [Display(Name = "Giới tính")]
        public string GioiTinh{ get; set; }
        [Display(Name = "Ngày sinh")]
        public DateTime NgaySinh { get; set; }



    }
}