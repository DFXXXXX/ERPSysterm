using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Sale
    {
        public int Saleid { get; set; }
        public DateTime? SaleTime { get; set; }
        public int? Payment { get; set; }
        public int? Custid { get; set; }
        public int? Perid { get; set; }
        public int? Total { get; set; }
        public string Rem { get; set; }
        public string Kt { get; set; }
        public int? Swid { get; set; }
    }
}
