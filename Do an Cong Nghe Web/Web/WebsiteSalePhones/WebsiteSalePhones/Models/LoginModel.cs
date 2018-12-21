using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebsiteSalePhones.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Nhập tên đăng nhập.")]
        public string TaiKhoan { set; get; }
        [Required(ErrorMessage = "Nhập mật khẩu.")]
        public string MatKhau { set; get; }
        public bool Remember { set; get; }
    }
}