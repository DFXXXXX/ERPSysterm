using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    /// <summary>
    /// 故障
    /// </summary>
    public partial class Breakdown
    {
        public int Brid { get; set; }
        public string Brname { get; set; }
        public int? Brnamecount { get; set; }
    }
}
