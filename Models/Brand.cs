using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    /// <summary>
    /// 品牌
    /// </summary>
    public partial class Brand
    {
        public int Brandid { get; set; }
        public string Brandname { get; set; }
        public int? Brandcount { get; set; }
    }
}
