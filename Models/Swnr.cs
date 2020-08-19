using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Swnr
    {
        public int Num { get; set; }
        public int? Swid { get; set; }
        public int? Component { get; set; }
        public int? Price { get; set; }
        public int? Count { get; set; }
        public int? Nrtotal { get; set; }
        public string Rem { get; set; }
        public int? Sprice { get; set; }
    }
}
