using System;
using System.Collections.Generic;

namespace ERPSysterm.Models
{
    /// <summary>
    /// 颜色
    /// </summary>
    public partial class Colour
    {
        public int Colourid { get; set; }
        public string Colourname { get; set; }
        public int? Colourcount { get; set; }
    }
}
