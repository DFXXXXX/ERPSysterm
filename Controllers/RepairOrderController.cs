using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSysterm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairOrderController : ControllerBase
    {
        private readonly SMDQContext context;
        public RepairOrderController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<RepairOrder>> GetAllRepairOrder()
        {
            List<RepairOrder> personnels = context.RepairOrder.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<RepairOrder>();
            return personnels;
        }
    }
}
