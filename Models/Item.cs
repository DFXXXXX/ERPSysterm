using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    /// <summary>
    /// 维修品
    /// </summary>
    public partial class Item
    {
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Itemcount { get; set; }
    }
}
