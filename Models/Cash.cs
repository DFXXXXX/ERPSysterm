using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    public partial class Cash
    {
        public int Num { get; set; }
        public int? Custid { get; set; }
        public int? Payment { get; set; }
        public int? Orderid { get; set; }
        public int? Count { get; set; }
        public DateTime? Mtime { get; set; }
        public int? Mtype { get; set; }
    }
}
