using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Storehouse
    {
        public int Component { get; set; }
        public string Barcode { get; set; }
        public string Comname { get; set; }
        public string Comcost { get; set; }
        public int? Comprice { get; set; }
        public int? Comcount { get; set; }
        public string Comrem { get; set; }
    }
}
