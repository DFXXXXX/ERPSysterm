using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPSysterm.Models
{
    public partial class Puser
    {
        public int Perid { get; set; }
        [Required(ErrorMessage = "用户名称不能为空")]
        public string Username { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Password { get; set; }
        public int? Rem { get; set; }
    }
}
