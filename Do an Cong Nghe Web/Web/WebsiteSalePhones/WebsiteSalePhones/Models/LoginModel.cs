using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteSalePhones.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name ="Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tên đăng nhập.")]
        public string TaiKhoan { set; get; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu.")]
        public string MatKhau { set; get; }
        public bool Remember { set; get; }
    }
}