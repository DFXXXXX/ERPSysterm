using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPSysterm.Models
{
    public partial class Personnel
    {
        public int Perid { get; set; }
        [Required(ErrorMessage = "用户名称不能为空")]
        public string Pername { get; set; }
        public string Pertel { get; set; }
        public string Perphoto { get; set; }
        public int? Perlv { get; set; }
        public DateTime? Entrytime { get; set; }
        public string Adr { get; set; }
        [Required(ErrorMessage = "密码不能为空")]
        public string Pwd { get; set; }
        public int? Authorization1 { get; set; }
        public int? Authorization2 { get; set; }
        public int? Authorization3 { get; set; }
        public int? Authorization4 { get; set; }
        public int? Authorization5 { get; set; }
        public int? Flag { get; set; }
    }
}
