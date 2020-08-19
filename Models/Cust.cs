using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPSysterm.Models
{
    public partial class Cust
    {
        public int Custid { get; set; }
        [Required(ErrorMessage = "名称不能为空")]
        public string Custname { get; set; }
        public int? Custtype { get; set; }
        public string Custtel { get; set; }
        public string Custadr { get; set; }
        public int? Custlv { get; set; }
        public int? Custamount { get; set; }
        public string Custrem { get; set; }
    }
}
