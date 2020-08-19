using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Supplier
    {
        public int Supid { get; set; }
        public string Supname { get; set; }
        public string Suptel { get; set; }
        public string Supadr { get; set; }
        public int? Supamount { get; set; }
        public string Suprem { get; set; }
    }
}
