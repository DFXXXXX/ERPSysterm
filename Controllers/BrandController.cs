using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSysterm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly SMDQContext context;
        public BrandController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Brand>> GetAllBrand()
        {
            List<Brand> personnels = context.Brand.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Brand>();
            return personnels;
        }
    }
}
