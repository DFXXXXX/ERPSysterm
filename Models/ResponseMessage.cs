using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSysterm.Models
{
    public  class ResponseMessage
    {
       private int Stute { get; set; }
        private string Message { get; set; }
        public  ResponseMessage FalseResponseMessage(string Mes)
        {
            return new ResponseMessage()
            {
                Stute = 0,
                Message = Mes
            };
        }
        public  ResponseMessage TrueResponseMessage(string Mes)
        {
            return new ResponseMessage()
            {
                Stute = 1,
                Message = Mes
            };
        }
    }
}
