using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Sw
    {
        public int Swid { get; set; }
        public int? Supid { get; set; }
        public DateTime? Swtime { get; set; }
        public string Swkey { get; set; }
        public int? Swtotal { get; set; }
    }
}
