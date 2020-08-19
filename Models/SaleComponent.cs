using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class SaleComponent
    {
        public int Id { get; set; }
        public int? Saleid { get; set; }
        public int? Compnent { get; set; }
        public int? Price { get; set; }
        public int? Comtype { get; set; }
        public int? Swid { get; set; }
        public string Rem { get; set; }
        public int? Cbprice { get; set; }
        public int? Sellcount { get; set; }
    }
}
