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
    public class ColourController : ControllerBase
    {
        private readonly SMDQContext context;
        public ColourController()
        {
            context = new SMDQContext();
    }
        public ActionResult<IEnumerable<Colour>> GetAllColour()
        {
            List<Colour> personnels = context.Colour.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Colour>();
            return personnels;
        }
    }
   

}
