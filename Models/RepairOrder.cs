using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    /// <summary>
    /// 维修
    /// </summary>
    public partial class RepairOrder
    {
        public int OId { get; set; }
        public int? Custid { get; set; }
        public int? Perid { get; set; }
        public string Itemname { get; set; }
        public string Pwd { get; set; }
        public string Brand { get; set; }
        public string Colour { get; set; }
        public string Fault { get; set; }
        public string Num { get; set; }
        public DateTime? OStartTime { get; set; }
        public DateTime? OFinishTime { get; set; }
        public int? OPrice { get; set; }
        public int? State { get; set; }
        public int? Amount { get; set; }
        public int? Payment { get; set; }
        public string Rem { get; set; }
        public int? Articleid { get; set; }
        public string Okey { get; set; }
        public int? Perid2 { get; set; }
        public DateTime? OEndtime { get; set; }
        public int? Zcb { get; set; }
    }
}
