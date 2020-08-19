using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Wxnr
    {
        public int Num { get; set; }
        public int? Wxid { get; set; }
        public int? Component { get; set; }
        public string Comname { get; set; }
        public int? Price { get; set; }
        public int? Mtype { get; set; }
        public int? Usetype { get; set; }
        public string Rem { get; set; }
        public int? Sprice { get; set; }
    }
}
