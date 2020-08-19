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

    public class BreakdownController : ControllerBase
    {
        private readonly SMDQContext context;
        public BreakdownController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Breakdown>> GetAllBreakdown()
        {
            List<Breakdown> personnels = context.Breakdown.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Breakdown>();
            return personnels;
        }
    }
}
